using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CaliburnMicroWpfExamples.ConductorExample
{
    class MainViewModel : Conductor<IScreen>
    {
        public void ShowRedScreen()
        {
            ActivateItem(new ScreenViewModel(Colors.Red)
            {
                DisplayName = "Red Screen",
            });
        }

        public void ShowGreenScreen()
        {
            ActivateItem(new ScreenViewModel(Colors.Green)
            {
                DisplayName = "Green Screen",
            });
        }

        public void ShowBlueScreen()
        {
            ActivateItem(new ScreenViewModel(Colors.Blue)
            {
                DisplayName = "Blue Screen",
            });
        }
    }
}
