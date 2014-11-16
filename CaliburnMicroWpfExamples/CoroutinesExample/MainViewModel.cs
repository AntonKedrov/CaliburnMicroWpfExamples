using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliburnMicroWpfExamples.CoroutinesExample
{
    class MainViewModel : PropertyChangedBase
    {
        private string _statusText;

        public string StatusText
        {
            get
            {
                return _statusText;
            }
            set
            {
                _statusText = value;
                NotifyOfPropertyChange(() => StatusText);
            }
        }

        private byte[] _loadedData;

        public byte[] LoadedData
        {
            get
            {
                return _loadedData;
            }
            set
            {
                _loadedData = value;
            }
        }

        public IEnumerable<IResult> Download()
        {
            yield return new Tasks.LoadData();
            yield return new Tasks.ShowData();
        }
    }
}
