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
        private List<DialogViewModel> _openWindows = new List<DialogViewModel>();

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
            _openWindows.Add(window);
            _windowManager.ShowWindow(window);
        }

        public void CloseAllWindows()
        {
            _openWindows.Apply((x) => x.TryClose());
            _openWindows.Clear();
        }

        public void ShowPopup()
        {
            _windowManager.ShowPopup(new PopupViewModel());
        }
    }
}
