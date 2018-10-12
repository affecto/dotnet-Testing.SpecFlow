using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using TechTalk.SpecFlow;

namespace Affecto.Testing.SpecFlow
{
    public static class TableRowExtensions
    {
        public static string ToTableString(this TableRow tableRow)
        {
            StringBuilder stringBuilder = new StringBuilder("| ");
            foreach (string column in tableRow.Values)
            {
                stringBuilder.Append(column);
                stringBuilder.Append(" | ");
            }

            return stringBuilder.ToString();
        }

        public static string GetOptionalValue(this TableRow row, string key)
        {
            return row.ContainsKey(key) ? row[key] : null;
        }

        public static DateTime? GetOptionalFinnishDate(this TableRow row, string key)
        {
            string dateString = GetOptionalValue(row, key);
            return string.IsNullOrWhiteSpace(dateString) ? (DateTime?) null : DateTime.ParseExact(dateString, "dd.MM.yyyy", CultureInfo.InvariantCulture);
        }

        public static IReadOnlyCollection<string> SplitCommaSeparatedText(this TableRow row, string key)
        {
            return row[key].Split(new[] { ", " }, StringSplitOptions.None);
        }
    }
}