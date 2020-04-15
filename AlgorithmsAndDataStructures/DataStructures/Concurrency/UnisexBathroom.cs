using System;
using System.Threading;

namespace AlgorithmsAndDataStructures.DataStructures.Concurrency
{
    public class UnisexBathroom
    {
        private Semaphore maleCounterSemaphor;
        private Semaphore femaleTurnSemaphore;
        private Semaphore maleTurnSemaphore;
        private Semaphore startvationPreventionSemaphore;
        private Semaphore femaleCounterSemaphor;
        private Semaphore occupiedSemaphor;
        private int maleCount;
        private int femaleCount;

        public UnisexBathroom()
        {
            this.maleCounterSemaphor = new Semaphore(0, 3);
            this.femaleCounterSemaphor = new Semaphore(0, 3);
            this.occupiedSemaphor = new Semaphore(0, 1);
            this.femaleTurnSemaphore = new Semaphore(0, 1);
            this.maleTurnSemaphore = new Semaphore(0, 1);
            this.startvationPreventionSemaphore = new Semaphore(0, 1);
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
