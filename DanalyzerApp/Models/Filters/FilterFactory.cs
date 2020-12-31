using DanalyzerControllerPrototype.Utilities.Enums;
using System;
using System.Collections.Generic;

namespace DanalyzerControllerPrototype.Models.Filters
{
    static class FilterFactory
    {
        public static IncludesFilter IncludesAnswersToQuestion(string question, ICollection<string> answers)
        {
            return new IncludesFilter(question, answers);
        }

        public static ExcludesFilter ExcludesAnswersToQuestion(string question, ICollection<string> answers)
        {
            return new ExcludesFilter(question, answers);
        }

        public static QuestionFilter FilterByTypeAnswersToQuestion(string question, ICollection<string> answers, QuestionFilterType type)
        {
            switch (type)
            {
                case QuestionFilterType.Includes:
                    return new IncludesFilter(question, answers);
                case QuestionFilterType.Excludes:
                    return new ExcludesFilter(question, answers);
            }
            throw new ArgumentException("Invalid filter type.");
        }

        public static Type GetQuestionFilterTypeFromEnum(QuestionFilterType type)
        {
            switch (type)
            {
                case QuestionFilterType.Excludes:
                    return typeof(ExcludesFilter);
                case QuestionFilterType.Includes:
                    return typeof(IncludesFilter);
            }
            throw new ArgumentException("Invalid type.");
        }
    }
}
