using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Support.V4.Widget;
using System.ComponentModel;
using System.Threading;

namespace Xamarin.SwipeRefresh
{
    [Activity(Label = "Xamarin.SwipeRefresh", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        SwipeRefreshLayout mSwipeRefreshLayout;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            mSwipeRefreshLayout = FindViewById<SwipeRefreshLayout>(SwipeRefresh.Resource.Id.swipe_layout);

            mSwipeRefreshLayout.SetColorSchemeColors(new int[] { -16776961, -16711681, -16711936, -65536 });

            mSwipeRefreshLayout.Refresh += MSwipeRefreshLayout_Refresh;
        }

        private void MSwipeRefreshLayout_Refresh(object sender, System.EventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();

            worker.DoWork += Worker_DoWork;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            worker.RunWorkerAsync();
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Update the UI.

            RunOnUiThread(()=> { mSwipeRefreshLayout.Refreshing = false; });
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            //Will run on seperate thread.

            Thread.Sleep(3000);
        }
    }
}

