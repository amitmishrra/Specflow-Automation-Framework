using System;
using System.IO;
using log4net;
using log4net.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[assembly: XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(UnitTest1));

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            // Ensure log4net is configured
            XmlConfigurator.Configure(new FileInfo("log4net.config"));
        }

        [TestMethod]
        public void TestMethod1()
        {
            using (var consoleOutput = new StringWriter())
            {
                Console.SetOut(consoleOutput);
                Console.WriteLine("Hello World");
                logger.Info("This is the test");

                string output = consoleOutput.ToString();
                logger.Info("Console output: " + output);

                // Optionally, write to debug output
                System.Diagnostics.Debug.WriteLine(output);
            }
        }
    }
}
