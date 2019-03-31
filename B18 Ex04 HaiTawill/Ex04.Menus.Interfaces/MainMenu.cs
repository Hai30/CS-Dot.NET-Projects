using System;
using System.Collections.Generic;
using System.Text;


namespace Ex04.Menus.Interfaces
{
    
    public class MainMenu
    {
        private MainItem m_RootOfMenuItem;

        public MainItem RootItem
        {
            set
            {
                m_RootOfMenuItem = value;
            }
            get
            {
                return m_RootOfMenuItem;
            }
       
        }

        public MainMenu(MainItem i_RootItem)
        {
            RootItem = i_RootItem;
        }

    
        public void Show()
        {
            ShowMenu(m_RootOfMenuItem, true);
        }

   
        private void ShowMenu(MainItem i_RootItem, bool i_IsThisMainMenu)
        {
            int InputChoice = 0;

            while (true)
            {
                Console.Clear();
                PrintMenu(i_RootItem, i_IsThisMainMenu);
                int SizeOfList = i_RootItem.MenuItemsList.Count;
                InputChoice = GetUserChoice(SizeOfList);
                
                if (InputChoice == 0)
                {
                    break;
                }
           
                 MainItem RootItem = i_RootItem.MenuItemsList[InputChoice - 1] as MainItem;
                    
                
                if (RootItem != null)
                {
                    ShowMenu(RootItem, false);
                }
                else
                {
                    Console.Clear();
                    ActionItem leafItem = i_RootItem.MenuItemsList[InputChoice - 1] as ActionItem;
                    leafItem.StartAction.DoAction(leafItem);
                    Console.WriteLine("Press any key to Back to previous menu...");
                    Console.ReadLine();
                }
            }
        }

        private void PrintMenu(MainItem i_RootItem, bool i_IsThisMainMenu)
        {
            StringBuilder ListOfItems = new StringBuilder();
            int m_OptionNum = 1;
            
            ListOfItems.AppendLine(i_RootItem.ItemName + ":");
            ListOfItems.AppendLine("===============================\n");
            foreach (MenuItem item in i_RootItem.MenuItemsList)
            {
                ListOfItems.AppendLine(m_OptionNum.ToString()+") - " + item.ItemName);
                m_OptionNum++;
            }
            if (i_IsThisMainMenu == true)
            {
                ListOfItems.AppendLine("\nPress 0  to exit the App!\n");
            }
            else
            {
                ListOfItems.AppendLine("\nPress  0  to back\n");
            }
 
            Console.WriteLine(ListOfItems.ToString());
        }

       
        private int GetUserChoice(int i_MenuSizeOfOptions)
        {
            string userChoice = Console.ReadLine();
            int intChoiceCount = 0;
            bool isLegalInput = false;

            while (!isLegalInput) 
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
            

            return intChoiceCount;
        }
    }
}