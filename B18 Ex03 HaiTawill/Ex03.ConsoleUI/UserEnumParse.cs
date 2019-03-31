using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class UserEnumParse
    {
        public T UserEnumParseofValue<T>(string i_Str)
        {
            T EnumToParse;

			try
			{
				EnumToParse = (T)Enum.Parse(typeof(T), i_Str);

			}
			catch
			{
				throw new ArgumentException("Not a currect enum type..");
			}
           return EnumToParse; 
        }
    }
}
