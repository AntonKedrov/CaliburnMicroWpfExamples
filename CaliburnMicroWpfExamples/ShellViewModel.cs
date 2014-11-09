using Caliburn.Micro;

namespace CaliburnMicroWpfExamples
{
    public class ShellViewModel : PropertyChangedBase, IShell
    {
        private readonly IWindowManager _windowManager;

        private string _dialogExampleResult;

        public string DialogExampleResult
        {
            get
            {
                return _dialogExampleResult;
            }
            set
            {
                _dialogExampleResult = value;
                NotifyOfPropertyChange(() => DialogExampleResult);
            }
        }

        public ShellViewModel(IWindowManager windowManager)
        {
            _windowManager = windowManager;
        }

        public void DialogExample()
        {
            bool? result = _windowManager.ShowDialog(new DialogExample.MainViewModel());

            if (result.HasValue)
                DialogExampleResult = result.Value.ToString();
            else
                DialogExampleResult = "NULL";
        }

        public void EventsExample()
        {
            _windowManager.ShowDialog(new EventsExample.MainViewModel());
        }

        public void MasterDetailExample()
        {
            _windowManager.ShowDialog(new MasterDetailExample.MainViewModel());
        }
    }
}