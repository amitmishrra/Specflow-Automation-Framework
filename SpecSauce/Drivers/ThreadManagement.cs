using System;
using System.Threading.Tasks;

namespace SpecSauce.Drivers
{
    public class ThreadManagement
    {
        public void RunInThreads(string[] browserNames, Action<string> callback)
        {
            Parallel.ForEach(browserNames, browserName =>
            {
                callback(browserName);
            });
        }
    }
}
