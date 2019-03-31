using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{
   
    public class MainMenu
    {
        private MainItem m_RootItem;

        public MainItem RootItem
        {
            set
            {
                m_RootItem = value;
            }
            get
            {
                return m_RootItem;
            }
           
        }

        public MainMenu(MainItem i_RootItem)
        {
            RootItem = i_RootItem;
        }

       
        public void Show()
        {
            ShowMenu(m_RootItem, true);
        }


        private void ShowMenu(MainItem i_RootItem, bool i_IsMainMenu)
        {
            int userChoice = 0;

            while (true)
            {
                Console.Clear();
                PrintMenu(i_RootItem, i_IsMainMenu);
                int SizeOfList = i_RootItem.MenuofItemsList.Count;
                userChoice = GetUserchoice(SizeOfList);
                if (userChoice == 0)
                {
                    break;
                }

                MainItem RootItem = i_RootItem.MenuofItemsList[userChoice - 1] as MainItem;

                if (RootItem != null)
                {
                    ShowMenu(RootItem, false);
                }
                else
                {
                    Console.Clear();
                    ActionItem leafItem = i_RootItem.MenuofItemsList[userChoice - 1] as ActionItem;
                    leafItem.RunAction();
                    Console.WriteLine("Press any key to Back to previous menu...");
                    Console.ReadKey();
                }
            }
        }


        private void PrintMenu(MainItem i_RootItem, bool i_IsThisMainMenu)
        {
            StringBuilder ListOfItems = new StringBuilder();
            int m_OptionNum = 1;

            ListOfItems.AppendLine(i_RootItem.ItemName + ":");
            ListOfItems.AppendLine("=================================\n");
            foreach (MenuItem item in i_RootItem.MenuofItemsList)
            {
                ListOfItems.AppendLine(m_OptionNum.ToString() + ") - " + item.ItemName);
                m_OptionNum++;
            }
            if (i_IsThisMainMenu == true)
            {
                ListOfItems.AppendLine("\nPress 0  to Inteface Menu!\n");
            }
            else
            {
                ListOfItems.AppendLine("\nPress  0  to back\n");
            }

            Console.WriteLine(ListOfItems.ToString());
        }


        private int GetUserchoice(int i_MenuSizeOfOptions)
        {
            string userChoice= Console.ReadLine();
            int intChoiceCount = 0;
            bool isLegalInput = false;

            do
            {
                try
                {
                    intChoiceCount = int.Parse(userChoice);

                    if (intChoiceCount >= 0 && intChoiceCount < i_MenuSizeOfOptions + 1)
                    {
                        isLegalInput = true;
                    }
                    else
                    {
                        isLegalInput = false;
                        Console.WriteLine("You insert a wrong value!please try again...");
                        userChoice = Console.ReadLine();
                        intChoiceCount = int.Parse(userChoice);
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("You insert a wrong value!please try again...");
                    userChoice = Console.ReadLine();
                    isLegalInput = false;
                }
            }
            while (!isLegalInput);

            return intChoiceCount;
        }
    }
}