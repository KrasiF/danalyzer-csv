using DanalyzerControllerPrototype.Utilities.Enums;
using System;
using System.Collections.Generic;

namespace DanalyzerControllerPrototype.Models.Filters
{
    public abstract class QuestionFilter : IFilter
    {
        protected abstract Func<Dictionary<string, string>, bool> FilterFunction { get; set; }

        public QuestionFilterType Type { get; protected set; }
        public string Question { get; protected set; }
        public ICollection<string> Answers { get; protected set; }

        public QuestionFilter(string question, ICollection<string> answers, QuestionFilterType type)
        {
            Question = question;
            Answers = answers;
            Type = type;
        }

        public List<Dictionary<string, string>> GetFilteredData(List<Dictionary<string, string>> data)
        {
            List<Dictionary<string, string>> toReturn = new List<Dictionary<string, string>>();
            
            foreach(var entry in data)
            {
                if (FilterFunction(entry))
                {
                    toReturn.Add(entry);
                }
            }
            return toReturn;
        }
    }
}
