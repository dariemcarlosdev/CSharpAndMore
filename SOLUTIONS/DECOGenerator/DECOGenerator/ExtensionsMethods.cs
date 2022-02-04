using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data;
using System.Reflection;

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

        public static List<T> DataTableToList<T>(DataTable dt)
        {
            List <T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }

            return data;
        }

        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }
    }

}
