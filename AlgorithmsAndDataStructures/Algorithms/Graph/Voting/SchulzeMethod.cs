using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.Voting
{
    public class SchulzeMethod
    {
#pragma warning disable CA1822 // Mark members as static
        public List<VotingScore> GetWinner(int[][] ballots, int numberOfCandidates)
#pragma warning restore CA1822 // Mark members as static
        {
            return GetBallotResults(ballots, numberOfCandidates)
                .Select((arg, index) => new VotingScore { Candidate = index, Score = arg.Count })
                .ToList();
        }

        private static IEnumerable<List<int>> GetBallotResults(IReadOnlyList<int[]> ballots, int numberOfCandidates)
        {
            var pairwisePreferences = CalculatePairwisePreferences(ballots, numberOfCandidates);
            var adjacencyMatrix = CreateAdjacencyMatrix(pairwisePreferences);
            var (strongestPath, _) = CalculateStrongestPath(adjacencyMatrix);

            return BallotResult(strongestPath);
        }

        private static IEnumerable<List<int>> BallotResult(IReadOnlyList<int[]> strongestPath)
        {
            var result = new List<int>[strongestPath.Count];

            for (var i = 0; i < result.Length; i++)
            {
                result[i] = new List<int>();
            }

            for (var i = 0; i < strongestPath.Count; i++)
            {
                for (var j = 0; j < strongestPath.Count; j++)
                {
                    if (i != j)
                    {
                        if (strongestPath[i][j] > strongestPath[j][i])
                        {
                            result[i].Add(j);
                        }
                    }
                }
            }

            return result;
        }

        // ReSharper disable once UnusedTupleComponentInReturnValue
        private static (int[][] strongestPath, int[][] path) CalculateStrongestPath(IReadOnlyList<int[]> adjacencyMatrix)
        {
            var numberOfCandidates = adjacencyMatrix.Count;
            var strongestPath = CreateEmptySquareMatrix(numberOfCandidates);
            var path = CreateEmptySquareMatrix(numberOfCandidates);

            for (var i = 0; i < strongestPath.Length; i++)
            {
                strongestPath[i] = new int[strongestPath.Length];
                path[i] = new int[numberOfCandidates];
            }

            for (var i = 0; i < numberOfCandidates; i++)
            {
                for (var j = 0; j < numberOfCandidates; j++)
                {
                    if (adjacencyMatrix[i][j] > adjacencyMatrix[j][i])
                    {
                        strongestPath[i][j] = adjacencyMatrix[i][j];
                        path[i][j] = i;
                    }
                    else
                    {
                        strongestPath[i][j] = int.MinValue;
                        path[i][j] = -1;
                    }
                }
            }

            for (var k = 0; k < numberOfCandidates; k++)
            {
                for (var i = 0; i < numberOfCandidates; i++)
                {
                    for (var j = 0; j < numberOfCandidates; j++)
                    {
                        if (i != j)
                        {
                            if (strongestPath[i][j] < Math.Min(strongestPath[i][k], strongestPath[k][j]))
                            {
                                strongestPath[i][j] = Math.Min(strongestPath[i][k], strongestPath[k][j]);
                                path[i][j] = path[k][j];
                            }
                        }
                    }
                }
            }

            return (strongestPath, path);
        }

        private static int[][] CreateAdjacencyMatrix(IReadOnlyList<int[]> pairwisePreferences)
        {
            var numberOfCandidates = pairwisePreferences.Count;

            var adjacencyMatrix = CreateEmptySquareMatrix(numberOfCandidates);

            for (var i = 0; i < numberOfCandidates; i++)
            {
                for (var j = 0; j < numberOfCandidates; j++)
                {
                    if (pairwisePreferences[i][j] > pairwisePreferences[j][i])
                    {
                        adjacencyMatrix[i][j] = pairwisePreferences[i][j] - pairwisePreferences[j][i];
                    }
                }
            }

            return adjacencyMatrix;
        }

        private static int[][] CalculatePairwisePreferences(IReadOnlyList<int[]> ballots, int numberOfCandidates)
        {
            var preferencesMatrix = CreateEmptySquareMatrix(numberOfCandidates);

            for (var i = 0; i < ballots.Count; i++)
            {
                var ballot = ballots[i];

                for (var j = 0; j < ballot.Length; j++)
                {
                    var candidate = ballot[j];

                    for (var k = j + 1; k < ballot.Length; k++)
                    {
                        preferencesMatrix[candidate][ballot[k]] += 1;
                    }
                }
            }

            return preferencesMatrix;
        }

        private static int[][] CreateEmptySquareMatrix(int numberOfCandidates)
        {
            var preferencesMatrix = new int[numberOfCandidates][];

            for (var i = 0; i < preferencesMatrix.Length; i++)
            {
                preferencesMatrix[i] = new int[preferencesMatrix.Length];
            }

            return preferencesMatrix;
        }
    }
}
