using DanalyzerControllerPrototype.Models.DataManipulator;

namespace DanalyzerApp.GUI.Windows
{
    public interface IFilterWindow
    {
        public Controller LinkedController { get; }

        public void Destroy();
    }
}
