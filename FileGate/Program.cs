using Grapevine;
using System;

namespace FileGate
{
    internal class Program
    {
        internal static void Main(string[] _)
        {
            if (Environment.GetEnvironmentVariable("FILEGATE_CODE") is null)
            {
                Console.WriteLine("Missing environment variable 'FILEGATE_CODE'. This must be set.");
                return;
            }

            using IRestServer server = RestServerBuilder.UseDefaults().Build();
            server.Start();
            Console.Read();
        }
    }
}