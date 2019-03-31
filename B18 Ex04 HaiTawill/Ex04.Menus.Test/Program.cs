namespace Ex04.Menus.Test
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Ex04.Menus.Interfaces;
    using Ex04.Menus.Delegates;


    public class Program
    {
        protected static void Main()
        {
            MenuApp.DelegateMenu();
            MenuApp.InterfaceMenu();
        }

    }
}
