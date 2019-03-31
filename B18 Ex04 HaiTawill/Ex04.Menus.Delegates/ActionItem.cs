using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public delegate void DoActionHandler();

    public class ActionItem : MenuItem
    {
        public event DoActionHandler DoAction;

        public ActionItem(string i_ItemName)
            : base(i_ItemName)
        {
        }

        public void RunAction()
        {
            if (DoAction != null)
            {
                DoAction.Invoke();
                
            }
        }
    }
}