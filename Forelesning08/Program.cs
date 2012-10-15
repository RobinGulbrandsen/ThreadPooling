using System;
using System.Threading;

namespace ThreadPooling
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Starting threads\n");
            Account acc = new Account(1000);
            Thread[] threads = new Thread[10];
            for (int i = 0; i < threads.Length; i++)
            {
                Thread t = new Thread(new ThreadStart(acc.DoTransactions));
                threads[i] = t;
            }
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Start();
            }

            //Hack to wait for the threads to complete
            while (!isDone(threads))
            {
                //Waiting for the method to return true

                /*
                 * Tell the loop to wait 100milisecounds before It checks again, this will
                 * make the program run <100ms slower but It will do this to save CPU time to
                 * other aspects of the program and other prosesses. un-comment the line
                */
                //Thread.Sleep(100);
            }

            Console.WriteLine("\nThreads are done\nPress a key to contineu..");
            Console.ReadKey();
        }

        /*
         *  Sends with the thread array you wish to wait for.  
         */
        static bool isDone(Thread[] threads)
        {
            int numberOfDone = 0;
            for (int i = 0; i < threads.Length; i++)
            {
                if (!threads[i].IsAlive)
                {
                    numberOfDone++;
                }
            }
            if (numberOfDone == threads.Length)
            {
                return true;
            }
            return false;
        }
    }
}