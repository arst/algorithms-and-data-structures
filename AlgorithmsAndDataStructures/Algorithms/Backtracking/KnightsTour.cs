using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms.Backtracking
{
    public class KnightsTour
    {
        private readonly int[] xCoordinateMoves = { 2, 1, -1, -2, -2, -1, 1, 2 };
        private readonly int[] yCoordinateMoves = { 1, 2, 2, 1, -1, -2, -2, -1 };

        public bool GetTour(int startingPointX = 0, int startingPointY = 0)
        {
            var result = CreateGameField();

            result[startingPointX][startingPointY] = 1;

            const int initialMove = 2;
            var hasResult = Move(result, startingPointX, startingPointY, initialMove);

            return hasResult;
        }

        private static int[][] CreateGameField()
        {
            var result = new int[8][];

            for (var i = 0; i < result.Length; i++)
            {
                result[i] = new int[8];
            }

            return result;
        }

        private bool Move(IReadOnlyList<int[]> result, int xPosition, int yPosition, int move)
        {
            // Need to subtract 1 since out initial move is 2. 
            if (move - 1 == result.Count * result.Count)
            {
                return true;
            }


            for (var i = 0; i < xCoordinateMoves.Length; i++)
            {
                var moveX = xPosition + xCoordinateMoves[i];
                var moveY = yPosition + yCoordinateMoves[i];

                var isSafeMove = IsSafeMove(result.Count, moveX, moveY);

                if (isSafeMove && result[moveX][moveY] == 0)

                {
                    result[moveX][moveY] = move;
                    if (Move(result, moveX, moveY, move + 1))
                    {
                        return true;
                    }

                    result[moveX][moveY] = 0;
                }
            }

            return false;
        }

        private static bool IsSafeMove(int length, int moveX, int moveY)
        {
            return moveX < length && moveY < length && moveX >= 0 && moveY >= 0;
        }
    }
}
