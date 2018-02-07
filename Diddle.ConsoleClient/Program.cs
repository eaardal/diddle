using System;
using Diddle.Core;

namespace Diddle.ConsoleClient
{
    internal class Program
    {
        public static void Main(string[] args)
        {
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
    }
}