using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.Voting
{
    public class SchulzeMethod
    {
        public List<VotingScore> GetWinner(int[][] ballots, int numberOfCandidates)
        {
            return GetBallotResults(ballots, numberOfCandidates)
                .Select((arg, index) => new VotingScore() { Candidate = index, Score = arg.Count })
                .ToList();
        }

        private static List<int>[] GetBallotResults(int[][] ballots, int numberOfCandidates)
        {
            var pairwisePreferences = CalculatePairwisePreferences(ballots, numberOfCandidates);
            var adjacencyMatrix = CreateAdjacencyMatrix(pairwisePreferences);
            var (strongestPath, _) = CalclateStrongestPath(adjacencyMatrix);

            return BallotResult(strongestPath);
        }

        private static List<int>[] BallotResult(int[][] strongestPath)
        {
            var result = new List<int>[strongestPath.Length];

            for (var i = 0; i < result.Length; i++)
            {
                result[i] = new List<int>();
            }

            for (var i = 0; i < strongestPath.Length; i++)
            {
                for (var j = 0; j < strongestPath.Length; j++)
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

        private static (int[][] strongestPath, int[][] path) CalclateStrongestPath(int[][] adjacencyMatrix)
        {
            var numberOfCandidates = adjacencyMatrix.Length;
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

        private static int[][] CreateAdjacencyMatrix(int[][] pairwisePreferences)
        {
            var numberOfCandidates = pairwisePreferences.Length;

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

        private static int[][] CalculatePairwisePreferences(int[][] ballots, int numberOfCandidates)
        {
            var preferencesMatrix = CreateEmptySquareMatrix(numberOfCandidates);

            for (var i = 0; i < ballots.Length; i++)
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
