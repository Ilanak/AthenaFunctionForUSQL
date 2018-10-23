using System;
using System.Collections.Generic;

namespace AthenaFunctionsForUSQL
{
    public class StringFunctions
    {
        /// <summary>
        /// Splits a string on the delimiter and returns the substring in the index.
        /// Index starts with 0. If the index is larger than the number of substrings, empty string is returned. 
        /// </summary>
        /// <param name="str">The string to split</param>
        /// <param name="delimiter">The delimiter</param>
        /// <param name="index">The index of the substring to return</param>
        /// <returns>The substring in the provided index, or empty string if index is higher than substrings length</returns>
        public static string SplitPart(string str, string delimiter, int index)
        {
            var stringArray = str.Split(new string[] {delimiter}, StringSplitOptions.RemoveEmptyEntries);
            if (index <= stringArray.Length - 1)
            {
                return stringArray[index];
            }
            return string.Empty;
        }

        /// <summary>
        /// Calculates Levenshtein distance between two strings.
        /// Snippet code take from: https://stackoverflow.com/a/9453762 
        /// </summary>
        /// <param name="a">string a</param>
        /// <param name="b">string b</param>
        /// <returns>The Levenshtein distance</returns>
        public static int LevenshteinDistance(string a, string b)
        {
            if (string.IsNullOrEmpty(a) && string.IsNullOrEmpty(b))
            {
                return 0;
            }

            if (string.IsNullOrEmpty(a))
            {
                return b.Length;
            }

            if (string.IsNullOrEmpty(b))
            {
                return a.Length;
            }

            int lengthA = a.Length;
            int lengthB = b.Length;
            var distances = new int[lengthA + 1, lengthB + 1];
            for (int i = 0; i <= lengthA; distances[i, 0] = i++) ;
            for (int j = 0; j <= lengthB; distances[0, j] = j++) ;

            for (int i = 1; i <= lengthA; i++)
            for (int j = 1; j <= lengthB; j++)
            {
                int cost = b[j - 1] == a[i - 1] ? 0 : 1;
                distances[i, j] = Math.Min
                (
                    Math.Min(distances[i - 1, j] + 1, distances[i, j - 1] + 1),
                    distances[i - 1, j - 1] + cost
                );
            }

            return distances[lengthA, lengthB];
        }

        /// <summary>
        /// Split string into a map by the entry delimiter and the key value delimiter.
        /// </summary>
        /// <param name="str">The string to split</param>
        /// <param name="entryDelimiter">The entry delimiter splits the string into key value pairs</param>
        /// <param name="keyValueDelimiter">The key value delimiter splits each pair to a key and a value</param>
        /// <returns>A dictionary of all the key-values pair</returns>
        public static Dictionary<string, string> SplitToMap(string str, string entryDelimiter, string keyValueDelimiter)
        {
            var keyValuePairs = str.Split(new string[] {entryDelimiter}, StringSplitOptions.RemoveEmptyEntries);
            var map = new Dictionary<string, string>();
            foreach (var kv in keyValuePairs)
            {
                var kvArray = kv.Split(new string[] {keyValueDelimiter}, StringSplitOptions.RemoveEmptyEntries);
                if (kvArray.Length != 2)
                {
                    throw new ArgumentException(
                        $"Expected for two values after splitting by {keyValueDelimiter}, but received {kvArray.Length}");
                }
                map.Add(kvArray[0], kvArray[1]);
            }

            return map;
        }
    }
}
