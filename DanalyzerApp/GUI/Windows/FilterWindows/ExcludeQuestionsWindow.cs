using DanalyzerApp.GUI.Windows;
using DanalyzerControllerPrototype.Models.DataManipulator;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace DanalyzerApp.GUI.FilterWindow
{
    class ExcludeQuestionsWindow : Border, IFilterWindow
    {
        Controller linkedController;
        ICollection<string> linkedQuestions;

        public Controller LinkedController
        {
            get
            {
                return linkedController;
            }
        }

        public ExcludeQuestionsWindow(Controller linkedController, ICollection<string> linkedQuestions) : base()
        {
            this.linkedController = linkedController;
            this.linkedQuestions = linkedQuestions;

            this.HorizontalAlignment = HorizontalAlignment.Stretch;
            this.BorderThickness = new Thickness(1);
            this.BorderBrush = Brushes.Black;
            var dockPanel = new DockPanel();            
            var txtBlock = new TextBlock();
            txtBlock.Inlines.Add(new Run() { Text = "- " });
            txtBlock.Inlines.Add(new Run() { Text = $"Q({linkedQuestions.Count})", ToolTip = string.Join(", ", linkedQuestions), Foreground = Brushes.Blue });
            txtBlock.Padding = new Thickness(3, 0, 0, 0);
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

        public ExcludeQuestionsWindow(Controller linkedController, string linkedQuestion) : this(linkedController, new List<string> { linkedQuestion }) { }

        public void Destroy()
        {
            this.LinkedController.RemoveQuestionsToTrim(this.linkedQuestions);
            (this.Parent as StackPanel).Children.Remove(this);
            MainWindow.mainWindow.DisplayData();
        }
    }
}
