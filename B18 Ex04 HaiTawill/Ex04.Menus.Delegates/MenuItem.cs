using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{

    public class MenuItem
    {
        private string m_ItemName = null;

        public string ItemName
        {
            set
            {
                m_ItemName = value;
            }
            get
            {
                return m_ItemName;
            }

        }

        public MenuItem(string i_ItemName)
        {
            ItemName = i_ItemName;
        }
    }
}