using DanalyzerApp.GUI.Windows;
using DanalyzerControllerPrototype.Models.DataManipulator;
using DanalyzerControllerPrototype.Models.Filters;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace DanalyzerApp.GUI.FilterWindow
{
    class QuestionFilterWindow : Border, IFilterWindow
    {
        Controller linkedController;
        QuestionFilter linkedFilter;

        public Controller LinkedController
        {
            get
            {
                return linkedController;
            }
        }

        public QuestionFilterWindow(Controller linkedController, QuestionFilter linkedFilter) : base()
        {
            this.linkedController = linkedController;
            this.linkedFilter = linkedFilter;

            this.HorizontalAlignment = HorizontalAlignment.Stretch;
            this.BorderThickness = new Thickness(1);
            this.BorderBrush = Brushes.Black;
            var dockPanel = new DockPanel();
            var txtBlock = new TextBlock();
            txtBlock.Inlines.Add(new Run() { Text = "+ " });
            txtBlock.Inlines.Add(new Run() { Text = $"A({linkedFilter.Answers.Count})", ToolTip = string.Join(", ",linkedFilter.Answers), Foreground = Brushes.Blue });
            txtBlock.Inlines.Add(new Run() { Text = " to " });
            txtBlock.Inlines.Add(new Run() { Text = "Q", ToolTip = linkedFilter.Question, Foreground = Brushes.Blue });
            Button removeButton = new Button();
            removeButton.Content = new Run() { Text = "✕", Foreground = Brushes.Red };
            removeButton.HorizontalAlignment = HorizontalAlignment.Right;
            removeButton.Click += (sender, e) =>
            {
                this.Destroy();
            };

            dockPanel.Children.Add(txtBlock);
            dockPanel.Children.Add(removeButton);

            this.Child = dockPanel;
        }

        public void Destroy()
        {
            this.linkedController.RemoveFilter(this.linkedFilter);
            (this.Parent as StackPanel).Children.Remove(this);
            MainWindow.mainWindow.DisplayData();
        }
    }
}
