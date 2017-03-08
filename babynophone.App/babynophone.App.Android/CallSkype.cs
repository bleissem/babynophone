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
using Microsoft.Practices.Unity;

namespace babynophone.App.Droid
{
    public class CallSkype : ICallSkype
    {
        public CallSkype(ISettings settings, IExecuteAction executeSkype)
        {
            m_Settings = settings;
            m_ExecuteAction = executeSkype;
        }

        ~CallSkype()
        {
            Dispose(false);
        }

        private ISettings m_Settings;
        private IExecuteAction m_ExecuteAction;

        public bool CanDial()
        {
            return m_ExecuteAction.CanExecute();
        }

        public void Dial()
        {
            m_ExecuteAction.Execute();
        }

        private void Dispose(bool disposing)
        {
            if (null != m_ExecuteAction)
            {
                m_ExecuteAction.Dispose();
                m_ExecuteAction = null;
            }

            if (null != m_Settings)
            {
                m_Settings = null;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}