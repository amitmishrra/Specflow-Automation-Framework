using System;
using System.Threading;

namespace SpecSauce.Utils
{
    public class ThreadRunner
    {
        // Define a delegate to represent the method to be executed
        public delegate void MethodToRun(String browser);

        public void ParallelExecuter(String[] browsersArray, MethodToRun method)
        {
            // Create an array of threads to store the threads
            System.Threading.Thread[] threads = new System.Threading.Thread[browsersArray.Length];

            // Start a thread for each index
            for (int i = 0; i < browsersArray.Length; i++)
            {
                int index = i; // Capture the current index for the lambda expression
                threads[i] = new System.Threading.Thread(() => method(browsersArray[index]));
                threads[i].Start();
            }

            // Wait for all threads to complete
            foreach (System.Threading.Thread thread in threads)
            {
                thread.Join();
            }
        }
    }
}