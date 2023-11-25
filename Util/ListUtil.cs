using System.Data;

namespace Util
{
    public static class ListUtil
    {
        public static List<T> BindList<T>(DataTable dt)
        {
            var fields = typeof(T).GetFields();
            List<T> lst = new List<T>();
            foreach (DataRow dr in dt.Rows)
            {
                var ob = Activator.CreateInstance<T>();
                foreach (var fieldInfo in fields)
                {
                    foreach (DataColumn dc in dt.Columns)
                    {
                        // Matching the columns with fields
                        if (fieldInfo.Name == dc.ColumnName)
                        {
                            // Get the value from the datatable cell
                            object value = dr[dc.ColumnName];

                            // Set the value into the object
                            fieldInfo.SetValue(ob, value);
                            break;
                        }
                    }
                }
                lst.Add(ob);
            }
            return lst;
        }
    }
}
