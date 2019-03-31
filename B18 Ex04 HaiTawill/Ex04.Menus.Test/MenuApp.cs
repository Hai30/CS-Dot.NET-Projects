using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus.Interfaces;
using Ex04.Menus.Delegates;

namespace Ex04.Menus.Test
{
    class MenuApp
    {
        public static void DelegateMenu()
        {

            Delegates.MainItem MainMenuDelegate = new Delegates.MainItem ("Welcome to Delegates Main Menu"); 
            
            Delegates.MainMenu delegatesMainMenu = new Delegates.MainMenu(MainMenuDelegate);

            Delegates.MainItem timeMenuDelegate = new Delegates.MainItem("Time Menu" );

            Delegates.ActionItem CapitalItemDelegate = new Delegates.ActionItem("Is Capital in sentence");

            Delegates.ActionItem showVersionItemDelegate = new Delegates.ActionItem("Show Version of system");

            Delegates.ActionItem showTimeItemDelegate = new Delegates.ActionItem("Show current Time");

            Delegates.ActionItem showDateItemDelegate = new Delegates.ActionItem("Show current Date");

            showTimeItemDelegate.DoAction += ShowCurrentTime;
            showDateItemDelegate.DoAction += ShowCurrentDate;
            CapitalItemDelegate.DoAction += IsCapitalInSentence;
            showVersionItemDelegate.DoAction += ShowVersionOfSystem;

            MainMenuDelegate.AddItem(timeMenuDelegate);
            timeMenuDelegate.AddItem(showTimeItemDelegate);
            timeMenuDelegate.AddItem(showDateItemDelegate);
            MainMenuDelegate.AddItem(CapitalItemDelegate);
            MainMenuDelegate.AddItem(showVersionItemDelegate);

            delegatesMainMenu.Show();
        }

        public static void InterfaceMenu()
        {
            Interfaces.MainItem MainMenuInterface = new Interfaces.MainItem("Welcome to Interfaces Main Menu");

            Interfaces.MainMenu iMainMenu = new Interfaces.MainMenu(MainMenuInterface);

            Interfaces.MainItem iTimeMenu = new Interfaces.MainItem("Time Menu - Interface");

            Interfaces.ActionItem iCapitalCounterItem = new Interfaces.ActionItem("Is Capital in sentence", new TestStartAction());

            Interfaces.ActionItem iShowVersionItem = new Interfaces.ActionItem("Show Version of system", new TestStartAction());

            Interfaces.ActionItem iShowTimeItem = new Interfaces.ActionItem("Show current Time", new TestStartAction());

            Interfaces.ActionItem iShowDateItem = new Interfaces.ActionItem("Show current Date", new TestStartAction());

            iTimeMenu.AddItem(iShowTimeItem);
            iTimeMenu.AddItem(iShowDateItem);
            MainMenuInterface.AddItem(iTimeMenu);
            MainMenuInterface.AddItem(iCapitalCounterItem);
            MainMenuInterface.AddItem(iShowVersionItem);
            iMainMenu.Show();

        }

        private static void ShowCurrentTime()
        {
            Console.WriteLine(DateTime.Now.ToString("hh:mm:ss tt"));
        }

        private static void ShowCurrentDate()
        {
            Console.WriteLine(DateTime.Now.ToShortDateString());
        }

        private static void IsCapitalInSentence()
        {
            string m_Sentence = null;
            int numOfCapitalInSentence = 0;


            Console.WriteLine("Hello! Please enter a sentence for capital letters check: ");
            m_Sentence = Console.ReadLine();
            for (int i = 0; i < m_Sentence.Length; i++)
            {
                if (char.IsUpper(m_Sentence[i]) == true)
                {
                    numOfCapitalInSentence++;
                }
            }


            Console.WriteLine("There is " + numOfCapitalInSentence + " capital letters in the sentence!");
        }

        private static void ShowVersionOfSystem()
        {
            Console.WriteLine("Version: 18.2.4.0");
        }

        
        protected class TestStartAction : IMenuActionHandler
        {
            public void DoAction(Interfaces.ActionItem i_LeafItem)
            {
                switch (i_LeafItem.ItemName)
                {
                    case "Show current Time":
                        ShowCurrentTime();
                        break;
                    case "Show current Date":
                        ShowCurrentDate();
                        break;
                    case "Is Capital in sentence":
                        IsCapitalInSentence();
                        break;
                    case "Show Version of system":
                        ShowVersionOfSystem();
                        break;

                }
            }
        }  
    }
}
