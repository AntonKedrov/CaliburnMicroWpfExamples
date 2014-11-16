using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliburnMicroWpfExamples.CoroutinesExample.Tasks
{
    class ShowData : IResult
    {
        public event EventHandler<ResultCompletionEventArgs> Completed;

        public void Execute(CoroutineExecutionContext context)
        {
            MainViewModel targetViewModel = context.Target as MainViewModel;
            targetViewModel.StatusText = String.Concat(targetViewModel.LoadedData.Length, " bytes loaded");

            Completed(this, new ResultCompletionEventArgs());
        }
    }
}
