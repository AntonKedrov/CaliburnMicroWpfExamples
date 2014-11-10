using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliburnMicroWpfExamples.EventAggregatorExample
{
    class SubscriberViewModel : Screen, IHandle<int>
    {
        private int _message;

        public int Message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
                NotifyOfPropertyChange(() => Message);
            }
        }

        public SubscriberViewModel(IEventAggregator eventAggregator)
        {
            eventAggregator.Subscribe(this);
        }

        public void Handle(int message)
        {
            Message = message;
        }
    }
}
