using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliburnMicroWpfExamples.MasterDetailExample
{
    class MainViewModel
    {
        public BindableCollection<DetailViewModel> Items
        {
            get;
            private set;
        }

        public MainViewModel()
        {
            Items = new BindableCollection<DetailViewModel>
			{
				new DetailViewModel { Id = Guid.NewGuid() },
				new DetailViewModel { Id = Guid.NewGuid() },
				new DetailViewModel { Id = Guid.NewGuid() },
				new DetailViewModel { Id = Guid.NewGuid() },
				new DetailViewModel { Id = Guid.NewGuid() }
			};
        }

        public void Add()
        {
            Items.Add(new DetailViewModel
            {
                Id = Guid.NewGuid()
            });
        }

        public void Remove(DetailViewModel item)
        {
            Items.Remove(item);
        }
    }
}
