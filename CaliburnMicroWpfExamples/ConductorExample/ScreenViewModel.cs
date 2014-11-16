using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CaliburnMicroWpfExamples.ConductorExample
{
    class ScreenViewModel : Screen
    {
        private SolidColorBrush _backgroundColor;

        public SolidColorBrush BackgroundColor
        {
            get
            {
                return _backgroundColor;
            }
            private set
            {
                _backgroundColor = value;
                NotifyOfPropertyChange(() => BackgroundColor);
            }
        }

        public ScreenViewModel(Color backgroundColor)
        {
            BackgroundColor = new SolidColorBrush(backgroundColor);
        }
    }
}
