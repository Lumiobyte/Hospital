using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hospital.UI.Components
{
    public static class DataTable
    {

        // Reflection + EF = infinite loops on navigation properties :(
        private static bool IsSafeProperty(PropertyInfo propertyInfo)
        {
            var propType = propertyInfo.PropertyType;
            if (propType.IsPrimitive || propType == typeof(string) || propType.IsValueType)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Render a tabular representation of the data contained in a list of objects
        public static void RenderTable<T>(IEnumerable<T> entities, bool showId = false)
        {

            if(entities == null || !entities.Any())
            {
                Console.WriteLine("There are no records to show!");
                return;
            }

            var properties = showId 
                ? typeof(T).GetProperties().Where(p => IsSafeProperty(p) && Attribute.IsDefined(p, typeof(TabulateAttribute))).ToList()
                : typeof(T).GetProperties().Where(p => IsSafeProperty(p) && Attribute.IsDefined(p, typeof(TabulateAttribute)) && p.Name.ToLower() != "id").ToList();

            var headers = properties.Select(h => SpaceHeaders(h.Name)).ToList();

            var rows = new List<List<string>>();
            foreach (var entity in entities)
            {
                var values = properties.Select(p => p.GetValue(entity)?.ToString() ?? "[no data]").ToList();
                rows.Add(values);
            }

            var columnWidths = new int[headers.Count];
            for (int i = 0; i < headers.Count; i++)
            {
                columnWidths[i] = Math.Max(headers[i].Length, rows.Max(r => r[i].Length));
            }

            string headerSeparator = new('-', columnWidths.Sum() + (columnWidths.Length - 1) * 3); // The added length accounts for the width added by column separators

            PrintRow(headers, columnWidths);
            Console.WriteLine(headerSeparator);

            foreach (var row in rows)
            {
                PrintRow(row, columnWidths);
            }
        }

        // Write a row to console and insert column separators where appropriate
        private static void PrintRow(List<string> row, int[] columnWidths)
        {
            bool first = true;
            int cwIterator = 0;
            foreach (var column in row)
            {
                if (first)
                    first = false;
                else
                    Console.Write(" | ");

                Console.Write(column);
                Console.Write(new string(' ', columnWidths[cwIterator] - column.Length)); // Padding generation
                
                cwIterator++;
            }

            Console.WriteLine();
        }

        // Converts camelCase or PascalCase to spaced format e.g. "EmailAddress" -> "Email Address"
        private static string SpaceHeaders(string columnName)
        {
            return Regex.Replace(columnName, "(?<!^)([A-Z])", " $1");
        }

    }
}
