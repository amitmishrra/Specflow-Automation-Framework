using log4net;
using NUnit.Framework;

namespace SpecSauce.StepDefinitions
{
    public class TestFile
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(TestFile));

        [Test]
        public void Test1()
        {
            log.Info("Close the Browser");
            Console.WriteLine("Hello World");
        }

        [Test]
        public void Test2()
        {
            log.Info("THis is test 2");
            Console.WriteLine("Hello World : Ek baar fir se");
        }
    }
}
