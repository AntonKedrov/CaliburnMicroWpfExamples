using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliburnMicroWpfExamples.EventAggregatorExample
{
    class MainViewModel : Screen
    {
        private readonly IWindowManager _windowManager;
        private readonly IEventAggregator _eventAggregator;

        private List<SubscriberViewModel> _openWindows = new List<SubscriberViewModel>();

        private int _value;

        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                NotifyOfPropertyChange(() => Value);
                _eventAggregator.PublishOnCurrentThread(value);
            }
        }

        public MainViewModel(IWindowManager windowManager, IEventAggregator eventAggregator)
        {
            _windowManager = windowManager;
            _eventAggregator = eventAggregator;
        }

        public void Up()
        {
            Value++;
        }

        public void Down()
        {
            Value--;
        }

        public void ShowSubscriber()
        {
            SubscriberViewModel subscriber = new SubscriberViewModel(_eventAggregator);
            _windowManager.ShowWindow(subscriber);
            _openWindows.Add(subscriber);
        }

        protected override void OnDeactivate(bool close)
        {
            if (close)
            {
                _openWindows.Apply((x) => x.TryClose());
                _openWindows.Clear();
            }
        }
    }
}
