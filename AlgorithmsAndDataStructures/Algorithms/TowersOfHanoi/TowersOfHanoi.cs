using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmsAndDataStructures.Algorithms.TowersOfHanoi
{
    public class TowersOfHanoi
    {
        private readonly char tempPeg;
        private readonly int numberOfDisks;
        private readonly char startPeg;
        private readonly char endPeg;
        private Queue<string> moves = new Queue<string>();

        public TowersOfHanoi(int numberOfDisks)
        {
            this.startPeg = 'A';
            this.endPeg = 'C';
            this.tempPeg = 'B';
            this.numberOfDisks = numberOfDisks;
        }

        public void Solve()
        {
            moves.Clear();
            SolveInternal(numberOfDisks, startPeg, endPeg, tempPeg);
        }

        private void SolveInternal(int numberfDisks, char startPeg, char endPeg, char tempPeg)
        {
            if (numberfDisks == 1)
            {
                moves.Enqueue($"Move 1: {startPeg} -> {endPeg}");
                return;
            }

            SolveInternal(numberfDisks - 1, startPeg, tempPeg, endPeg);
            moves.Enqueue($"Move {numberfDisks}: {startPeg} -> {endPeg}");
            SolveInternal(numberfDisks - 1, tempPeg, endPeg, startPeg);
        }

        public IReadOnlyCollection<string> GetLastSolutionMoves()
        {
            return moves.ToList();
        }

    }
}
