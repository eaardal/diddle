using System;
using Diddle.Core;

namespace Diddle.ConsoleClient
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                if (args.Length != 1)
                {
                    PrintHelp();
                    return;
                }

                switch (args[0])
                {
                    case "on":
                        FiddlerIISProxy.On();
                        break;
                    case "off":
                        FiddlerIISProxy.Off();
                        break;
                    case "status":
                        var status = FiddlerIISProxy.Status();
                        if (status)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("On");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Off");
                         
                        }
                        Console.ResetColor();
                        break;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private static void PrintHelp()
        {
            const string help =
                @"
Diddle
==============================
on        Turn on Diddle (Enables the proxy)
off       Turn off Diddle (Disables the proxy)
status    Get the current status (is proxy on/off)
";
            Console.WriteLine(help);
        }
    }
}