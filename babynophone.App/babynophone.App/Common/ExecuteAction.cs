using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace babynophone.App.Common
{
    public class ExecuteAction : IExecuteAction
    {

        public ExecuteAction(Action action):this(action, ()=>true)
        {
        }

        public ExecuteAction(Action action, Func<bool> canExecute)
        {
            m_Action = action;
            m_CanExecute = canExecute;
        }

        ~ExecuteAction()
        {
            this.Dispose(false);
        }

        private Func<bool> m_CanExecute;
        private Action m_Action;

        private void Dispose(bool disposing)
        {
            if (null != m_Action)
            {
                m_Action = null;
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public bool CanExecute()
        {
            if (null == m_CanExecute) return false;
            return m_CanExecute();
        }

        public void Execute()
        {
            if (!CanExecute()) return;
            if (null == m_Action)
            {
                return;
            }

            m_Action();
        }
    }


    public class ExecuteGenericAction<T> : IExecuteGenericAction<T>
    {
        public ExecuteGenericAction(Action<T> action):this(action, ()=>true)
        {

        }

        public ExecuteGenericAction(Action<T> action, Func<bool> canExecute)
        {
            m_Action = action;
            m_CanExecute = canExecute;
        }

        ~ExecuteGenericAction()
        {
            this.Dispose(false);
        }

        private Func<bool> m_CanExecute;
        private Action<T> m_Action;

        private void Dispose(bool disposing)
        {
            if (null != m_Action)
            {
                m_Action = null;
            }

            if (null != m_CanExecute)
            {
                m_CanExecute = null;
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private T m_Value;

        public void SetValue(T value)
        {
            m_Value = value;
        }

        public bool CanExecute()
        {
            if (null == m_CanExecute) return false;
            return m_CanExecute();
        }

        public void Execute()
        {
            if (null == m_Action)
            {
                return;
            }
            m_Action(m_Value);
        }
    }
}
