using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliburnMicroWpfExamples.WindowManagerExample
{
    class MainViewModel : PropertyChangedBase
    {
        private readonly IWindowManager _windowManager;
        private Stack<DialogViewModel> _openWindows = new Stack<DialogViewModel>();

        private string _modalDialogResult;

        public string ModalDialogResult
        {
            get
            {
                return _modalDialogResult;
            }
            set
            {
                _modalDialogResult = value;
                NotifyOfPropertyChange(() => ModalDialogResult);
            }
        }

        public MainViewModel(IWindowManager windowManager)
        {
            _windowManager = windowManager;
        }

        public void ShowModalDialog()
        {
            bool? result = _windowManager.ShowDialog(new DialogViewModel());

            if (result.HasValue)
                ModalDialogResult = result.Value.ToString();
            else
                ModalDialogResult = "NULL";
        }

        public void ShowWindow()
        {
            DialogViewModel window = new DialogViewModel();
            _openWindows.Push(window);
            _windowManager.ShowWindow(window);
        }

        public void CloseAllWindows()
        {
            DialogViewModel window = null;

            while (_openWindows.Count > 0 && (window = _openWindows.Pop()) != null)
            {
                window.TryClose();
            }
        }
    }
}
