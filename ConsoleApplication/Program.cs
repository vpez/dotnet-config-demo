using System;

namespace ConsoleApplication
{
    internal class Program
    {

        private string _name = "";
        
        public static void Main(string[] args)
        {
            AppConfig config = new AppConfig();
            var keys = config.GetKeys(AppConfig.CognitiveServiceVendor.Microsoft, "speech");
            keys.ForEach(Console.WriteLine);
        }
    }
}