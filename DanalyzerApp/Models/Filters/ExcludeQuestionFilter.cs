using DanalyzerControllerPrototype.Models.Filters;
using System.Collections.Generic;

namespace Danalyzer.Models.Filters
{
    class ExcludeQuestionsFilter : IFilter
    {
        public ICollection<string> ToExclude { get; private set; }

        public ExcludeQuestionsFilter(ICollection<string> toExclude)
        {
            this.ToExclude = toExclude;
        }

        public ExcludeQuestionsFilter(string toExclude)
        {
            this.ToExclude = new List<string>();
            this.ToExclude.Add(toExclude);
        }

        public List<Dictionary<string, string>> GetFilteredData(List<Dictionary<string, string>> data)
        {
            List<Dictionary<string, string>> trimmedData = new List<Dictionary<string, string>>();
            foreach (var entry in data)
            {
                Dictionary<string, string> trimmedEntry = new Dictionary<string, string>();

                foreach (string key in entry.Keys)
                {
                    if (!ToExclude.Contains(key))
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
