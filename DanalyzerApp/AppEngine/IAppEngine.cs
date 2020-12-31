using DanalyzerApp.GUI.Windows;
using DanalyzerControllerPrototype.Models.DataManipulator;
using DanalyzerControllerPrototype.Utilities.Enums;
using System.Collections.Generic;

namespace DanalyzerApp.AppEngine
{
    interface IAppEngine
    {
        public Controller Controller { get; }

        public ICollection<IFilterWindow> FilterWindows { get; }

        public void AddQuestionFilterWindow(string question, ICollection<string> answers, QuestionFilterType type);

        public void AddExcludeQuestionWindow(string question);

        public void RemoveFilterWindow(IFilterWindow filterWindow);

        public void DisplayData();

        public void ClearFilters();

        public void InitializeController();
    }
}
