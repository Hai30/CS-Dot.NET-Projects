using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{

    public class ActionItem : MenuItem
    {
        private IMenuActionHandler m_StartAction;

        public IMenuActionHandler StartAction
        {
            get { return this.m_StartAction; }
            set { this.m_StartAction = value; }
        }

        public ActionItem(string i_ItemName, IMenuActionHandler i_IStartAction) : base(i_ItemName)
        {
            this.m_StartAction = i_IStartAction;
        }
    }
}