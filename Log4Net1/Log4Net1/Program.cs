using log4net;
using System;
using System.Reflection;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace Log4Net1
{
    public class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private static void Main(string[] args)
        {
            Log.Debug("Application is starting");
            Console.WriteLine("Test Line");
            var testClass = new TestClass();
            testClass.LogSomething();

            Log.Debug("Application is ending");
            Console.Read();
        }

        public class TestClass
        {
            private static readonly ILog Log2 = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

            public void LogSomething()
            {
                for (int i = 0; i < 100; i++)
                {
                    Log2.InfoFormat("CurrentTime is [{0}]", DateTime.Now.ToString("yyyy.MM.dd-hh.mm.ss~fff"));
                }
            }
        }
    }
}