using System.Windows.Controls;

namespace DanalyzerApp.GUI.Windows
{
    public class ColumnHeaderContextMenu : ContextMenu
    {
        public string Question { get; private set; }

        public ColumnHeaderContextMenu(string question) : base()
        {
            this.Question = question;
            this.Items.Add(CreateFilterMenuItem());
            this.Items.Add(CreateExcludeMenuItem());
        }

        MenuItem CreateFilterMenuItem()
        {
            var menuItem = new MenuItem();
            menuItem.Header = "Filter";
            menuItem.Click += (sender, e) =>
            {
                var createFilterWindow = new CreateFilterWindow(Question);
                createFilterWindow.Show();
            };
            return menuItem;
        }

        MenuItem CreateExcludeMenuItem()
        {
            var menuItem = new MenuItem();
            menuItem.Header = "Hide";
            menuItem.Click += (sender, e) =>
            {
                MainWindow.mainWindow.AddExcludeQuestionWindow(Question);
            };
            return menuItem;
        }
    }
}
