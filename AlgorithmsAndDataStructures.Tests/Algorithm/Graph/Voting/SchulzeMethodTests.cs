using AlgorithmsAndDataStructures.Algorithms.Graph.Voting;
using System.Linq;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Graph.Voting
{
    public class SchulzeMethodTests
    {
        [Fact]
        public void Base()
        {
            var sut = new SchulzeMethod();

            var ballots = new int[20][];

            for (var i = 0; i < 10; i++)
            {
                ballots[i] = new int[3];
                ballots[i][0] = 0;
                ballots[i][1] = 1;
                ballots[i][2] = 2;
            }

            for (var i = 10; i < 15; i++)
            {
                ballots[i] = new int[3];
                ballots[i][0] = 1;
                ballots[i][1] = 2;
                ballots[i][2] = 0;
            }

            for (var i = 15; i < 20; i++)
            {
                ballots[i] = new int[3];
                ballots[i][0] = 2;
                ballots[i][1] = 0;
                ballots[i][2] = 1;
            }

            var ballotWinners = sut.GetWinner(ballots, 3);

            Assert.Equal(0, ballotWinners.First().Candidate);
            Assert.Equal(2, ballotWinners.First().Score);

            Assert.Equal(1, ballotWinners.Skip(1).First().Candidate);
            Assert.Equal(1, ballotWinners.Skip(1).First().Score);

            Assert.Equal(2, ballotWinners.Skip(2).First().Candidate);
            Assert.Equal(0, ballotWinners.Skip(2).First().Score);
        }
    }
}
