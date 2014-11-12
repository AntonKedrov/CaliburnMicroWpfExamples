using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace CaliburnMicroWpfExamples.WindowManagerExample
{
    class PopupViewModel : Screen
    {
        private Timer _popupCountdown = new Timer(new TimeSpan(0, 0, 5).TotalMilliseconds);

        public PopupViewModel()
        {
            _popupCountdown.Elapsed += _popupCountdown_Elapsed;
            _popupCountdown.Start();
        }

        void _popupCountdown_Elapsed(object sender, ElapsedEventArgs e)
        {
            TryClose();
        }
    }
}
