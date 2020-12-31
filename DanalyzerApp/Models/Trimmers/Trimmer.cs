using System;
using System.Collections.Generic;
using System.Linq;

namespace DanalyzerControllerPrototype.Models.Trimmers
{
    static class Trimmer
    { 
        public static List<Dictionary<string, string>> TrimData(List<Dictionary<string, string>> data, string[] excludeQuestions)
        {
            List<Dictionary<string, string>> trimmedData = new List<Dictionary<string, string>>();
            foreach (var entry in data)
            {
                Dictionary<string, string> trimmedEntry = new Dictionary<string, string>();

                foreach(string key in entry.Keys)
                {
                    if (!excludeQuestions.Contains(key))
                    {
                        trimmedEntry.Add(key, entry[key]);
                    }
                }

                trimmedData.Add(trimmedEntry);
            }
            return trimmedData;
        }
    }
}
