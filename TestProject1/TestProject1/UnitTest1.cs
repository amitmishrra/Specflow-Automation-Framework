
using log4net;
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config")]

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(UnitTest1));

        public UnitTest1()
        {
            
        }

        [TestMethod]
        public void TestMethod1()
        {
            Console.WriteLine("Hello World Amit");
            log.Info("This is the test");
        }
    }
}
