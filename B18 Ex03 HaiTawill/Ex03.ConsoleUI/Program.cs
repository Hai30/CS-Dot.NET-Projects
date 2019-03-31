using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("**Welcome to garage system App!**");
            Console.WriteLine("==================================");
            UserInterface userIN = new UserInterface();
            userIN.AppMenu();
        }
    }
}
