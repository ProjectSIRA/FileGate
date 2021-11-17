﻿using Grapevine;
using System;

namespace FileGate
{
    internal class Program
    {
        private static bool _running = false;

        internal static void Main(string[] _)
        {
            if (Environment.GetEnvironmentVariable("FILEGATE_CODE") is null)
            {
                Console.WriteLine("Missing environment variable 'FILEGATE_CODE'. This must be set.");
                return;
            }

            using IRestServer server = RestServerBuilder.UseDefaults().Build();
            server.Start();

            Console.CancelKeyPress += Console_CancelKeyPress;

            _running = true;
            while (_running) { }
        }

        private static void Console_CancelKeyPress(object? sender, ConsoleCancelEventArgs e)
        {
            Console.CancelKeyPress -= Console_CancelKeyPress;
            e.Cancel = true;
            _running = false;
        }
    }
}