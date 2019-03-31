using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public interface IMenuActionHandler
    {
        void DoAction(ActionItem i_LeafItem);
    }
}