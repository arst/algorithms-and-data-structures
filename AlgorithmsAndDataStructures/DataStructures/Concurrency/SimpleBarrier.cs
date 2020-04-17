namespace AlgorithmsAndDataStructures.DataStructures.Concurrency
{
    public class SimpleBarrier
    {
        private int counter;
        private int total;
        private bool released;
        private object counterLock = new object();

        public SimpleBarrier(int size)
        {
            counter = 0;
            total = size;
        }

        public void Wait()
        {
            var localWait = !released;

            lock (counterLock)
            {
                counter++;

                if (counter == total)
                {
                    counter = 0;
                    released = localWait;
                }
            }
            while (released != localWait)
            {
            }
        }
    }
}
