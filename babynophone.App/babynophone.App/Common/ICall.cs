﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace babynophone.App.Common
{
    public interface ICall : IDisposable
    {
        bool CanCall { get; }
        void Call();
    }
}
