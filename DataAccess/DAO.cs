using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Runtime.Serialization;

namespace DataAccess
{
    public class DAO
    {
        protected internal static List<T> DataTableToObjectList<T>(DataTable objectTable)
        {
            List<T> oneList = new List<T>();
            foreach (DataRow row in objectTable.Rows)
            {
                T obj = loadObject<T>(row);
                oneList.Add(obj);
            }

            return oneList;
        }

        protected internal static T DataTableToObject<T>(DataTable objectTable)
        {
            T obj = default(T);

            if (objectTable.Rows.Count > 0)
             obj = loadObject<T>(objectTable.Rows[0]);

            return obj;
        }

        private static T loadObject<T>(DataRow row)
        {
            Type objectType = typeof(T);
            //T obj = null;

            //PropertyInfo[] pi = objectType.GetProperties((BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
            //    .Where(p => Attribute.IsDefined(p, typeof(DataMemberAttribute))).ToArray<PropertyInfo>();

            PropertyInfo[] pi = objectType.GetProperties().ToArray<PropertyInfo>();
            T obj = (T)Activator.CreateInstance(objectType);

            foreach (PropertyInfo infoElement in pi)
            {
                if(!infoElement.IsSpecialName)
                {
                    if (row.Table.Columns.Contains(infoElement.Name))
                    {
                        if (row[infoElement.Name] == DBNull.Value)
                        {
                            infoElement.SetValue(obj, null, null);
                        }
                        else
                        {
                            infoElement.SetValue(obj, Convert.ChangeType(row[infoElement.Name], Type.GetType(infoElement.PropertyType.FullName)), null);
                        }
                    }
                    else
                    {
                        infoElement.SetValue(obj, null, null);
                    }
                }                

            }

            return obj;
        }
    }
}
