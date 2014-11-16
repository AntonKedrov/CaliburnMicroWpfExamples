using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliburnMicroWpfExamples.ConductorExample.Collections.AllActive
{
    class MainViewModel : Conductor<IScreen>.Collection.AllActive
    {
        private int _screenCount = 0;

        private IScreen _selectedItem;

        public IScreen SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
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
            ActivateItem(SelectedItem);
            NotifyOfPropertyChange(() => CanRemove);
        }
    }
}
