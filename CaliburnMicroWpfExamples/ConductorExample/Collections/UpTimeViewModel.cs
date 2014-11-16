using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace CaliburnMicroWpfExamples.ConductorExample.Collections
{
    class UpTimeViewModel : Screen
    {
        private Timer _timer = new Timer(1000);

        private int _secondsElapsed;

        public int SecondsElapsed
        {
            get
            {
                return _secondsElapsed;
            }
            set
            {
                _secondsElapsed = value;
                NotifyOfPropertyChange(() => SecondsElapsed);
            }
        }

        protected override void OnInitialize()
        {
            _timer.Elapsed += _timer_Elapsed;
        }

        protected override void OnActivate()
        {
            _timer.Start();
        }

        protected override void OnDeactivate(bool close)
        {
            _timer.Stop();

            if (close)
                _timer.Elapsed -= _timer_Elapsed;
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            SecondsElapsed++;
        }
    }
}
