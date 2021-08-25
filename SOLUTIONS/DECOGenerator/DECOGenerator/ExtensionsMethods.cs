using System;
using System.Collections.Generic;
using System.Text;

namespace CLAIMGenerator
{
    public static class ExtensionsMethods
    {
            public static string InsertInPositions(this string str, List<int> pos, string value)
        {
            string strOut = str;
            for (int i = 0; i < pos.Count; i++)
            {
                strOut =  strOut.Insert(pos[i], value);
            }
            return strOut;
           
        }
    }
}
