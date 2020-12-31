using DanalyzerControllerPrototype.Utilities.Enums;
using System;
using System.Collections.Generic;

namespace DanalyzerControllerPrototype.Models.Filters
{
    class IncludesFilter : QuestionFilter
    {
        protected override Func<Dictionary<string, string>, bool> FilterFunction { get; set; }

        public IncludesFilter(string question, ICollection<string> answers) : base(question, answers, QuestionFilterType.Includes)
        {
            Func<Dictionary<string, string>, bool> filterFunction = new Func<Dictionary<string, string>, bool>((dict) =>
            {
                return answers.Contains(dict[question]);
            });

            FilterFunction = filterFunction;
        }
    }
}
