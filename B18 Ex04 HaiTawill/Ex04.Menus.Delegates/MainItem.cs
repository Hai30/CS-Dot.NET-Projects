using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{

    public class MainItem : MenuItem
    {
        private readonly List<MenuItem> m_MenuItemsList = null;

        public List<MenuItem> MenuofItemsList
        {
            get { return m_MenuItemsList; }
        }

        public MainItem(string i_ItemName)
            : base(i_ItemName)
        {
            m_MenuItemsList = new List<MenuItem>(0);
        }

        public void AddItem(MenuItem i_MenuItemToAdd)
        {
            m_MenuItemsList.Add(i_MenuItemToAdd);
        }
    }
}