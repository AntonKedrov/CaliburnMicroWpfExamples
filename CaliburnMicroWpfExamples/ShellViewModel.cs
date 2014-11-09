using Caliburn.Micro;

namespace CaliburnMicroWpfExamples
{
    public class ShellViewModel : PropertyChangedBase, IShell
    {
        private readonly IWindowManager _windowManager;

        private string _dialogResult;

        public string DialogResult
        {
            get
            {
                return _dialogResult;
            }
            set
            {
                _dialogResult = value;
                NotifyOfPropertyChange(() => DialogResult);
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
                DialogResult = result.Value.ToString();
            else
                DialogResult = "NULL";
        }
    }
}