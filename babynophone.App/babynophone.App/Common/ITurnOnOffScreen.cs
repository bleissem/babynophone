using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace babynophone.App.Common
{
    public interface ITurnOnOffScreen : IDisposable
    {
        void TurnOn();
        void TurnOff();
    }
}
