using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace babynophone.App.Common
{
    public interface IExecuteAction : IDisposable
    {
        bool CanExecute();
        void Execute();
    }

    public interface IExecuteGenericAction<T> : IDisposable
    {
        void SetValue(T value);

        bool CanExecute();
        void Execute();

    }
}
