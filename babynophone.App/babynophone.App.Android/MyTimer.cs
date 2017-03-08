using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using babynophone.App.Common;

namespace babynophone.App.Droid
{
    public class MyTimer : System.Timers.Timer, ITimer
    {

        #region constructor 

        public MyTimer(TimeSpan timespan) : base(timespan.TotalMilliseconds)
        {
            base.Elapsed += MyTimer_Elapsed;
        }

        #endregion

        private void MyTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (null != MyElapsed)
            {
                MyElapsed(sender, new MyTimerElapsedEventArgs());
            }
        }

        public event MyTimerElapsedEventArgs.OnElapsed MyElapsed;

        protected override void Dispose(bool disposing)
        {
            base.Elapsed -= MyTimer_Elapsed;
            base.Dispose(disposing);            
        }
    }
}