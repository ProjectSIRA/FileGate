using Grapevine;
using System;

namespace FileGate
{
    internal class Program
    {
        internal static void Main(string[] _)
        {
            using IRestServer server = RestServerBuilder.UseDefaults().Build();
            server.Start();

            Console.ReadLine();
        }
    }
}
