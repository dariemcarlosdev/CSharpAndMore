using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data;

namespace CLAIMGenerator
{
    public static class ExtensionsMethods
    {
        //Extension Method to Insert Chart in given positions.
            public static string InsertInPositions(this string str, List<int> pos, string value)
        {
            string strOut = str;
            for (int i = 0; i < pos.Count; i++)
            {
                strOut =  strOut.Insert(pos[i], value);
            }
            return strOut;
           
        }

        //Extension Method to convert Datatable to Generic List.

        public static List<DataRow> DataTableToList(this DataTable dt)
        {
            List<DataRow> list = dt.Rows.Cast<DataRow>().ToList();
            return list;
        }
    }

}
