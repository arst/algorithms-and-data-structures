using System.Threading;

namespace AlgorithmsAndDataStructures.DataStructures.Concurrency
{
    public class SleepingBarber
    {
        private static Mutex numberOfCustomers = new Mutex();
        private Semaphore clientsSemaphore;
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
                numberOfCustomers.WaitOne();

                if (currentClients < waitChairCounter)
                {
                    currentClients++;
                    clientsSemaphore.Release();
                    numberOfCustomers.ReleaseMutex();
                    barberSemaphore.WaitOne();
                }
                else
                {
                    numberOfCustomers.ReleaseMutex();
                }
            }
        }

        public void Work()
        {
            while (true)
            {
                clientsSemaphore.WaitOne();
                numberOfCustomers.WaitOne();
                currentClients--;
                barberSemaphore.Release();
                numberOfCustomers.ReleaseMutex();

            }
        }
    }
}
