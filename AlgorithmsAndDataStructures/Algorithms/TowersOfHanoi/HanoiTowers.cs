using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms.TowersOfHanoi;

public class HanoiTowers
{
    private readonly char endPeg;
    private readonly Queue<string> moves = new();
    private readonly int numberOfDisks;
    private readonly char startPeg;
    private readonly char tempPeg;

    public HanoiTowers(int numberOfDisks)
    {
        startPeg = 'A';
        endPeg = 'C';
        tempPeg = 'B';
        this.numberOfDisks = numberOfDisks;
    }

    public void Solve()
    {
        moves.Clear();
        SolveInternal(numberOfDisks, startPeg, endPeg, tempPeg);
    }

    private void SolveInternal(int disksLeft, char start, char end, char temp)
    {
        if (disksLeft == 1)
        {
            moves.Enqueue($"Move 1: {start} -> {end}");
            return;
        }

        SolveInternal(disksLeft - 1, start, temp, end);
        moves.Enqueue($"Move {disksLeft}: {start} -> {end}");
        SolveInternal(disksLeft - 1, temp, end, start);
    }
}