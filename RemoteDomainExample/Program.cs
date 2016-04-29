using System;
using System.IO;

namespace RemoteDomainExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string relativePath = "..\\..\\..\\..\\TestLibrary\\bin\\Debug";

            // get the current path path
            string path = Path.Combine(typeof(Program).Assembly.Location, relativePath);
            path = Path.GetFullPath(new Uri(path).LocalPath);

            var appDomainSetup = new AppDomainSetup
            {
                ApplicationBase = path,
                PrivateBinPath = path,
                ApplicationName = AppDomain.CurrentDomain.SetupInformation.ApplicationName,
                LoaderOptimization = LoaderOptimization.MultiDomain
            };

            // create domain
            var appDomain = AppDomain.CreateDomain("MyDomain", null, appDomainSetup);

            var type = typeof(TestProxy.TestProxy);

            // create proxy
            var proxy = (TestProxy.TestProxy)appDomain.CreateInstanceFromAndUnwrap(type.Assembly.Location, type.FullName);
            proxy.Connect("TestLibrary.TestClass,TestLibrary");

            var result = proxy.ReturnString();

            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
