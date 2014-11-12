using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliburnMicroWpfExamples.WindowManagerExample
{
    class DialogViewModel : Screen
    {
        public void OK()
        {
            try
            {
                TryClose(true);
            }
            catch (Exception ex)
            {
                HandleInvalidOperationException(ex);
            }
        }

        public void Cancel()
        {
            try
            {
                TryClose(false);
            }
            catch (Exception ex)
            {
                HandleInvalidOperationException(ex);
            }
        }

        private void HandleInvalidOperationException(Exception ex)
        {
            if (ex.InnerException is InvalidOperationException)
                throw ex.InnerException;
            else
                throw ex;
        }
    }
}
