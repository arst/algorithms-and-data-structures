using System.Threading;

namespace AlgorithmsAndDataStructures.DataStructures.Concurrency
{
    public class SleepingBarber
    {
        private static readonly Mutex NumberOfCustomers = new Mutex();
        private readonly Semaphore clientsSemaphore;
        private readonly Semaphore barberSemaphore;
        private readonly int waitChairCounter;
        private volatile int currentClients;

        public SleepingBarber(int waitChairCounter)
        {
            clientsSemaphore = new Semaphore(0, 3);
            barberSemaphore = new Semaphore(0, 1);
            this.waitChairCounter = waitChairCounter;
            var barber = new Thread(Work);
            barber.Start();
        }

        public void Enter()
        {
            while (true)
            {
                NumberOfCustomers.WaitOne();

                if (currentClients < waitChairCounter)
                {
                    currentClients++;
                    clientsSemaphore.Release();
                    NumberOfCustomers.ReleaseMutex();
                    barberSemaphore.WaitOne();
                }
                else
                {
                    NumberOfCustomers.ReleaseMutex();
                }
            }
        }

        public void Work()
        {
            while (true)
            {
                clientsSemaphore.WaitOne();
                NumberOfCustomers.WaitOne();
                currentClients--;
                barberSemaphore.Release();
                NumberOfCustomers.ReleaseMutex();

            }
        }
    }
}
