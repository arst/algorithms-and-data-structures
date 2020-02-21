using System;

namespace AlgorithmsAndDataStructures.Algorithms.Backtracking
{
    public class KnightsTour
    {
        public bool GetTour(int startingPointX = 0, int startingPointY = 0)
        {
            var result = new int[8][];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new int[8];
            }

            var xCoordinateMoves = new int[] { 2, 1, -1, -2, -2, -1, 1, 2 };
            var yCoordinateMoves = new int[] { 1, 2, 2, 1, -1, -2, -2, -1 };
            result[startingPointX][startingPointY] = 1;
            var hasResult = Move(result, startingPointX, startingPointY, 2, xCoordinateMoves, yCoordinateMoves);

            return hasResult;
        }

        private bool Move(int[][] result, int xPosition, int yPosition, int move, int[] xCoordinateMoves, int[] yCoordinateMoves)
        {
            //need to substract one since we are not starting with 0
            if (move - 1 == result.Length * result.Length)
            {
                return true;
            }

            for (int i = 0; i < xCoordinateMoves.Length; i++)
            {
                int moveX = xPosition + xCoordinateMoves[i];
                int moveY = yPosition + yCoordinateMoves[i];

                var isSafeMove = IsSafeMove(result.Length, moveX, moveY);

                if (isSafeMove && result[moveX][moveY] == 0)

                {
                    result[moveX][moveY] = move;
                    if (Move(result, moveX, moveY, move + 1, xCoordinateMoves, yCoordinateMoves))
                    {
                        return true;
                    }
                    else
                    {
                        result[moveX][moveY] = 0;
                    }
                }
            }

            return false;
        }

        private bool IsSafeMove(int length, int moveX, int moveY)
        {
            return moveX < length && moveY < length && moveX >= 0 && moveY >= 0;
        }
    }
}
