using System;
using System.Threading;
using System.Threading.Tasks;
using Acr.UserDialogs;
namespace DemoApp.Base.Models
{
    public static class LoadingDialog
    {
        private static IProgressDialog _dialog;
        private static ProgressDialogConfig _config = new ProgressDialogConfig()
            .SetMaskType(MaskType.Black)
            .SetTitle("Loading")
            .SetIsDeterministic(false);
        static Task task;
        private static CancellationTokenSource tokenSource2;
        private static bool isDisposed;

        public static async void ShowDialog()
        {
            _dialog = UserDialogs.Instance.Progress(_config);
            _dialog.Show();
            isDisposed = false;

            tokenSource2 = new CancellationTokenSource();
            CancellationToken ct = tokenSource2.Token;

            task = Task.Run(() =>
            {
                Thread.Sleep(15000);
                // Were we already canceled?
                ct.ThrowIfCancellationRequested();

                if (!isDisposed && !ct.IsCancellationRequested && _dialog != null && _dialog.IsShowing)
                    Toast.MakeWarning("Something went wrong", 3);

                _dialog?.Hide();
                _dialog = null;
            }, tokenSource2.Token); // Pass same token to Task.Run.

            try
            {
                await task;
            }
            catch (OperationCanceledException e)
            {
                //Console.WriteLine($"{nameof(OperationCanceledException)} thrown with message: {e.Message}");
            }
            finally
            {
                tokenSource2.Dispose();
                isDisposed = true;
            }
        }

        public static void HideDialog()
        {
            _dialog?.Hide();
            _dialog = null;
            if (!isDisposed && tokenSource2.Token != null)
                tokenSource2.Cancel();
        }
    }
}
