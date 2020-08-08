using System;
using System.Threading;

namespace AlgorithmsAndDataStructures.DataStructures.Concurrency
{
    public class UnisexBathroom
    {
        private readonly Semaphore maleCounterSemaphor;
        private readonly Semaphore femaleTurnSemaphore;
        private readonly Semaphore maleTurnSemaphore;
        private readonly Semaphore startvationPreventionSemaphore;
        private readonly Semaphore femaleCounterSemaphor;
        private readonly Semaphore occupiedSemaphor;
        private int maleCount;
        private int femaleCount;

        public UnisexBathroom()
        {
            maleCounterSemaphor = new Semaphore(0, 3);
            femaleCounterSemaphor = new Semaphore(0, 3);
            occupiedSemaphor = new Semaphore(0, 1);
            femaleTurnSemaphore = new Semaphore(0, 1);
            maleTurnSemaphore = new Semaphore(0, 1);
            startvationPreventionSemaphore = new Semaphore(0, 1);
        }

        public void Enter(int gender)
        {
            if (gender == 0)
            {
                EnterMale();
            }
            else
            {
                EnterFemale();
            }
        }

        private void EnterFemale()
        {
            startvationPreventionSemaphore.WaitOne();
            femaleTurnSemaphore.WaitOne();
            femaleCount += 1;

            if (femaleCount == 1)
            {
                occupiedSemaphor.WaitOne();
            }

            femaleTurnSemaphore.Release();
            startvationPreventionSemaphore.Release();

            femaleCounterSemaphor.WaitOne();

            Console.WriteLine("In a bathroom F.");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            femaleCounterSemaphor.Release();
            femaleTurnSemaphore.WaitOne();
            femaleCount -= 1;

            if (femaleCount == 0)
            {
                occupiedSemaphor.Release();
            }

            femaleTurnSemaphore.Release();
        }

        private void EnterMale()
        {
            startvationPreventionSemaphore.WaitOne();
            maleTurnSemaphore.WaitOne();

            maleCount += 1;

            if (maleCount == 1)
            {
                occupiedSemaphor.WaitOne();
            }

            maleTurnSemaphore.Release();
            startvationPreventionSemaphore.Release();
            maleCounterSemaphor.WaitOne();

            Console.WriteLine("In a bath room M.");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            maleCounterSemaphor.Release();

            maleTurnSemaphore.WaitOne();

            maleCount -= 1;

            if (maleCount == 0)
            {
                occupiedSemaphor.Release();
            }

            maleTurnSemaphore.Release();
        }
    }
}
