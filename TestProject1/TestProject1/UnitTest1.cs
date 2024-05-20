using log4net;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config")]
namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private readonly ILog logger = LogManager.GetLogger(typeof(UnitTest1));
        [TestMethod]
        public void TestMethod1()
        {
            Console.WriteLine("Hello World");
            logger.Info("this is the test");
        }
    }
}