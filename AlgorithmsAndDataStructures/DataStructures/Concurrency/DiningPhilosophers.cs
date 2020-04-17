using System.Threading;

namespace AlgorithmsAndDataStructures.DataStructures.Concurrency
{
    public class DiningPhilosophers
    {
        private Semaphore fork0 = new Semaphore(1,1);
        private Semaphore fork1 = new Semaphore(1, 1);
        private Semaphore fork2 = new Semaphore(1, 1);
        private Semaphore fork3 = new Semaphore(1, 1);
        private Semaphore fork4 = new Semaphore(1, 1);

        public void Dine(int philosopher)
        {
            switch (philosopher)
            {
                case 0:
                    fork0.WaitOne();
                    fork4.WaitOne();
                    fork4.Release();
                    fork0.Release();
                    break;
                case 1:
                    fork0.WaitOne();
                    fork1.WaitOne();
                    fork1.Release();
                    fork0.Release();
                    break;
                case 2:
                    fork1.WaitOne();
                    fork2.WaitOne();
                    fork2.Release();
                    fork1.Release();
                    break;
                case 3:
                    fork2.WaitOne();
                    fork3.WaitOne();
                    fork3.Release();
                    fork2.Release();
                    break;
                case 4:
                    fork3.WaitOne();
                    fork4.WaitOne();
                    fork4.Release();
                    fork3.Release();
                    break;
                default:
                    break;
            }
        }
    }
}
