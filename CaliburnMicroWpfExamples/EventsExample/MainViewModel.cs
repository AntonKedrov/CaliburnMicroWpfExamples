using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliburnMicroWpfExamples.EventsExample
{
    class MainViewModel : PropertyChangedBase
    {
        private string _result;

        public string Result
        {
            get
            {
                return _result;
            }
            set
            {
                _result = value;
                NotifyOfPropertyChange(() => Result);
            }
        }

        public void Time()
        {
            Result = DateTime.Now.TimeOfDay.ToString();
        }

        public void Time(string format)
        {
            try
            {
                Result = DateTime.Now.ToString(format);
            }
            catch (Exception ex)
            {
                Result = ex.Message;
            }
        }

        public void MessageParam(object obj)
        {
            Result = obj.ToString();
        }
    }
}
