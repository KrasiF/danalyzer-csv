using DanalyzerApp.AppEngine;
using DanalyzerApp.GUI.FilterWindow;
using DanalyzerApp.GUI.Windows;
using DanalyzerControllerPrototype.Models.DataManipulator;
using DanalyzerControllerPrototype.Models.Filters;
using DanalyzerControllerPrototype.Utilities.Enums;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Dynamic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;

namespace DanalyzerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IAppEngine
    {
        public bool FileOpened
        {
            get
            {
                return fileOpened;
            }
            set
            {
                fileOpened = value;
                createFilterMenuItem.IsEnabled = value;

            }
        }

        public static MainWindow mainWindow;

        Controller controller;

        string path;

        bool fileOpened;

        public ICollection<IFilterWindow> filterWindows;

        public Controller Controller
        {
            get
            {
                return controller;
            }
            private set
            {
                controller = value;
            }
        }

        public ICollection<IFilterWindow> FilterWindows
        {
            get
            {
                return filterWindows;
            }
            private set
            {
                filterWindows = value;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            MainWindow.mainWindow = this;
        }

        public void AddExcludeQuestionWindow(ICollection<string> questions)
        {
            controller.AddQuestionsToTrim(questions);
            filterPanel.Children.Add(new ExcludeQuestionsWindow(controller, questions));
            DisplayData();
        }

        public void AddExcludeQuestionWindow(string question)
        {
            AddExcludeQuestionWindow(new List<string> { question });
        }

        public void AddQuestionFilterWindow(string question, ICollection<string> answers, QuestionFilterType type)
        {
            QuestionFilter filter = FilterFactory.FilterByTypeAnswersToQuestion(question, answers, type);
            controller.AddQuestionFilter(filter);
            filterPanel.Children.Add(new QuestionFilterWindow(controller, filter));
            DisplayData();
        }

        public void ClearFilters()
        {
            foreach (IFilterWindow filterWindow in filterWindows)
            {
                filterWindow.Destroy();
            }
        }

        public void DisplayData()
        {
            mainDataGrid.Columns.Clear();
            mainDataGrid.Items.Clear();
            var data = Controller.GetFilteredData();
            Controller.AddQuestionToTrim("Timestamp");
            var questions = Controller.GetQuestionsFromFiltered();

            foreach (string question in questions)
            {
                TextBlock txtBlock = new TextBlock(new Run(question));
                txtBlock.ContextMenu = new ColumnHeaderContextMenu(question);
                var col = new DataGridTextColumn() { Header = txtBlock };
                col.Binding = new Binding(question);
                mainDataGrid.Columns.Add(col);
            }

            foreach (var entry in data)
            {
                var eo = new ExpandoObject();
                var eoColl = (ICollection<KeyValuePair<string, object>>)eo;

                foreach (var kvp in entry)
                {
                    KeyValuePair<string, object> kv = new KeyValuePair<string, object>(kvp.Key, kvp.Value);
                    eoColl.Add(kv);
                }

                dynamic eoDynamic = eo;

                mainDataGrid.Items.Add(eoDynamic);
            }
        }

        public void InitializeController()
        {
            Controller = new Controller(path);
            FileOpened = true;
            DisplayData();
        }

        public void RemoveFilterWindow(IFilterWindow filterWindow)
        {
            filterWindow.Destroy();
        }

        private void ResetApp()
        {
            controller.Clear();
            filterWindows.Clear();
            filterPanel.Children.Clear();
            FileOpened = false;
            DisplayData();
        }

        public void Browse_Clicked(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Csv file (*.csv)|*.csv";
            openFileDialog.FileOk += (sender, e) =>
            {
                if (FileOpened)
                {
                    ResetApp();
                }
                path = openFileDialog.FileName;
                InitializeController();
            };
            openFileDialog.ShowDialog();
        }

        public void CreateFilter_Clicked(object sender, RoutedEventArgs e)
        {
            var createFilterWindow = new CreateFilterWindow();
            createFilterWindow.Show();
        }
    }
}
