using Danalyzer.Models.Filters;
using DanalyzerControllerPrototype.Models.Filters;
using DanalyzerControllerPrototype.Models.Readers;
using DanalyzerControllerPrototype.Utilities.Enums;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace DanalyzerControllerPrototype.Models.DataManipulator
{
    public class Controller
    {
        List<IFilter> filters;
        CsvReader csvReader;
        List<Dictionary<string, string>> data;
        ICollection<string> questionsToTrim;

        public Controller(CsvReader csvReader)
        {
            questionsToTrim = new List<string>();
            filters = new List<IFilter>();
            this.csvReader = csvReader;
            data = csvReader.GetDictionaryFromCsv();
        }

        public Controller(string path) : this(new CsvReader(path)) { }

        public void AddIncludeFilter(string question, ICollection<string> answers)
        {
            filters.Add(FilterFactory.IncludesAnswersToQuestion(question, answers));
        }

        public bool RemoveIncludeFilter(string question, ICollection<string> answers)
        {
            var filterToDelete = filters
                .Where(n=> (n is QuestionFilter))
                .Select(n=>n as QuestionFilter)
                .FirstOrDefault(n => n.Question == question && n.Answers.All(answers.Contains) && answers.Count == n.Answers.Count && n.Type == QuestionFilterType.Includes);

            if (filterToDelete == null)
            {
                return false;
            }

            return filters.Remove(filterToDelete);
        }

        public void AddQuestionFilter(QuestionFilter filter)
        {
            this.filters.Add(filter);
        }

        public void AddExcludeFilter(string question, ICollection<string> answers)
        {
            filters.Add(FilterFactory.ExcludesAnswersToQuestion(question, answers));
        }

        public bool RemoveExcludeFilter(string question, ICollection<string> answers)
        {
            var filterToDelete = filters
                .Where(n => (n is QuestionFilter))
                .Select(n => n as QuestionFilter)
                .FirstOrDefault(n => n.Question == question && n.Answers.All(answers.Contains) && answers.Count == n.Answers.Count &&  n.Type == QuestionFilterType.Excludes);

            if (filterToDelete == null)
            {
                return false;
            }

            return filters.Remove(filterToDelete);
        }

        public bool RemoveFilter(IFilter filter)
        {
            return this.filters.Remove(filter);
        }

        public void AddQuestionToTrim(string question)
        {
            if (!questionsToTrim.Contains(question))
            {
                questionsToTrim.Add(question);
            }
        }

        public bool RemoveQuestionToTrim(string question)
        {
            return questionsToTrim.Remove(question);
        }

        public void AddQuestionsToTrim(ICollection<string> questions)
        {
            foreach(var question in questions)
            {
                AddQuestionToTrim(question);
            }
        }

        public void RemoveQuestionsToTrim(ICollection<string> questions)
        {
            foreach (var question in questions)
            {
                RemoveQuestionToTrim(question);
            }
        }

        private void FilterData()
        {
            ResetData();
            foreach(QuestionFilter filter in filters)
            {
                data = filter.GetFilteredData(data);
            }
            data = new ExcludeQuestionsFilter(questionsToTrim).GetFilteredData(data);
        }

        public ImmutableList<Dictionary<string, string>> GetFilteredData()
        {
            FilterData();
            return data.ToImmutableList();
        }

        public string[] GetQuestionsFromFiltered()
        {
            FilterData();
            return data[0].Keys.ToArray();
        }

        public void Clear()
        {
            ResetData();
            questionsToTrim = new List<string>();
            filters = new List<IFilter>();
        }

        private void ResetData()
        {
            data = csvReader.GetDictionaryFromCsv();
        }
    }
}
