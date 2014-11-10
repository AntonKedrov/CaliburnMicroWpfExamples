using Caliburn.Micro;

namespace CaliburnMicroWpfExamples
{
    public class ShellViewModel : PropertyChangedBase, IShell
    {
        private readonly IWindowManager _windowManager;
        private readonly IEventAggregator _eventAggregator;

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

        public ShellViewModel(IWindowManager windowManager, IEventAggregator eventAggregator)
        {
            _windowManager = windowManager;
            _eventAggregator = eventAggregator;
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

        public void EventAggregatorExample()
        {
            _windowManager.ShowDialog(new EventAggregatorExample.MainViewModel(_windowManager, _eventAggregator));
        }
    }
}