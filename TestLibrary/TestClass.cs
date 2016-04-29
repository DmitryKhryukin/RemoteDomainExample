using System;
using System.Diagnostics;
using System.IO;
using TestProxy;

namespace TestLibrary
{
    public class TestClass : ITestInterface
    {
        public string ReturnString()
        {
            var result = "";

            try
            {
                // var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                // var currentDirectory = Environment.CurrentDirectory;

                // try to read file from currentDirectory, not from app domain base directory
                // we can use path
                // var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TextFile1.txt");
                result = File.ReadAllText("TextFile1.txt");
            }
            catch(Exception ex)
            {
                result = ex.Message;
            }


            return result;
        }
    }
}
