
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private readonly ILogger _logger;

        public UnitTest1()
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });

            _logger = loggerFactory.CreateLogger("SpecFlowLogger");
        }

        [TestMethod]
        public void TestMethod1()
        {
            Console.WriteLine("Hello World");
            _logger.LogInformation("This is the test");
        }
    }
}
