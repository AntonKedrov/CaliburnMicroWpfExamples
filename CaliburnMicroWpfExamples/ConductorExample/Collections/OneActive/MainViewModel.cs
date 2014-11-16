using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliburnMicroWpfExamples.ConductorExample.Collections.OneActive
{
    class MainViewModel : Conductor<IScreen>.Collection.OneActive
    {
        private int _screenCount = 0;

        public IScreen SelectedItem
        {
            get
            {
                return ActiveItem;
            }
            set
            {
                ActivateItem(value);
                NotifyOfPropertyChange(() => SelectedItem);
            }
        }

        public bool CanRemove
        {
            get
            {
                return (SelectedItem != null);
            }
        }

        public void Remove()
        {
            Items.Remove(SelectedItem);
            SelectedItem = Items.FirstOrDefault();
            NotifyOfPropertyChange(() => CanRemove);
        }

        public void Add()
        {
            SelectedItem = new UpTimeViewModel()
            {
                DisplayName = String.Concat("Screen", _screenCount++)
            };
            NotifyOfPropertyChange(() => CanRemove);
        }
    }
}
