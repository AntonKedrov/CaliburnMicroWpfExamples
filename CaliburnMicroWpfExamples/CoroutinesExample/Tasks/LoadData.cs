using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CaliburnMicroWpfExamples.CoroutinesExample.Tasks
{
    class LoadData : IResult
    {
        public event EventHandler<ResultCompletionEventArgs> Completed;

        private MainViewModel _targetViewModel;

        public void Execute(CoroutineExecutionContext context)
        {
            _targetViewModel = context.Target as MainViewModel;

            Uri dataURL = new Uri("http://download.thinkbroadband.com/5MB.zip");

            WebClient client = new WebClient();
            client.DownloadProgressChanged += client_DownloadProgressChanged;
            client.DownloadDataCompleted += client_DownloadDataCompleted;
            client.DownloadDataAsync(dataURL);
        }

        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            _targetViewModel.StatusText = String.Concat(e.ProgressPercentage, '%');
        }

        void client_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            _targetViewModel.LoadedData = e.Result;
            Completed(this, new ResultCompletionEventArgs());
        }
    }
}
