using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace babynophone.App.Common
{
    public interface ITimer : IDisposable
    {
        bool AutoReset { get; set; }

        double Interval { get; set; }


        event MyTimerElapsedEventArgs.OnElapsed MyElapsed;

        void Start();

        void Stop();
    }

    public class MyTimerElapsedEventArgs
    {

        public MyTimerElapsedEventArgs()
        {
        }
        
        public delegate void OnElapsed(object sender, MyTimerElapsedEventArgs args);
    }

}
