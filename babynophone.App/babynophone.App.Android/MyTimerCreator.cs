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
    public class MyTimerCreator : ICreateTimer
    {

        public ITimer Create(TimeSpan timespan)
        {
            return new MyTimer(timespan);
        }
    }
}