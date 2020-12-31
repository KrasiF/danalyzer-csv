using DanalyzerControllerPrototype.Utilities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace DanalyzerApp.GUI.Windows
{
    /// <summary>
    /// Interaction logic for CreateFilterWindow.xaml
    /// </summary>
    public partial class CreateFilterWindow : Window
    {
        MainWindow mainWindow;

        string Question 
        { 
            get
            {
                return questionInput.Text;
            }
        }

        List<string> Answers { get; set; }

        public CreateFilterWindow()
        {
            InitializeComponent();
            mainWindow = MainWindow.mainWindow;
            Answers = new List<string>();
        }

        public CreateFilterWindow(string question) : this()
        {
            questionInput.Text = question;
        }

        private void CloseWindow()
        {
            this.Close();            
        }

        private void addAnswerButton_Click(object sender, RoutedEventArgs e)
        {
            if (Answers.Contains(answerInput.Text))
            {
                MessageBox.Show("Answer has already beed added.");
                return;
            }
            Answers.Add(answerInput.Text);
            answersBlock.Text = String.Join(", ", Answers);
            answerInput.Text = "";
        }

        private void createFilterButton_Click(object sender, RoutedEventArgs e)
        {
            if (!mainWindow.Controller.GetQuestionsFromFiltered().Contains(Question))
            {
                MessageBox.Show("Invalid question.");
                return;
            }
            if(typeInput.SelectedIndex == -1)
            {
                MessageBox.Show("Select a type first.");
                return;
            }
            if(Answers.Count == 0)
            {
                MessageBox.Show("You have to add at least one answer.");
                return;
            }
            QuestionFilterType type = (QuestionFilterType)typeInput.SelectedIndex;
            mainWindow.AddQuestionFilterWindow(Question, Answers, type);
            CloseWindow();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            CloseWindow();
        }
    }
}
