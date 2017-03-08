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
    public class TurnOnOffScreen : ITurnOnOffScreen
    {
        public TurnOnOffScreen(Window window)
        {
            m_Window = window;
            WindowManagerFlags screenFlags = WindowManagerFlags.ShowWhenLocked | WindowManagerFlags.TurnScreenOn | WindowManagerFlags.KeepScreenOn | WindowManagerFlags.DismissKeyguard;
            m_TurnOff = new ExecuteAction(() =>
            {
                try
                {
                    m_Window.AddFlags(screenFlags);
                    var attributes = new WindowManagerLayoutParams();
                    attributes.CopyFrom(m_Window.Attributes);
                    attributes.ScreenBrightness = 0f;
                    m_Window.Attributes = attributes;
                }
                catch
                {

                }
            });
            m_TurnOn = new ExecuteAction(() =>
            {

                try
                {
                    m_Window.ClearFlags(screenFlags);
                    var attributes = new WindowManagerLayoutParams();
                    attributes.CopyFrom(m_Window.Attributes);
                    attributes.ScreenBrightness = -1f;
                    m_Window.Attributes = attributes;
                }
                catch
                {

                }
            });
        }

        ~TurnOnOffScreen()
        {
            this.Dispose(false);
        }

        Window m_Window;

        private IExecuteAction m_TurnOn;
        private IExecuteAction m_TurnOff;

        public void TurnOff()
        {
            m_TurnOff.Execute();
        }

        public void TurnOn()
        {
            m_TurnOn.Execute();
        }

        private void CleanUpWakeLock()
        {
            if (null != m_TurnOn)
            {
                try
                {
                    m_TurnOn.Dispose();
                }
                catch
                {

                }

                m_TurnOn = null;
            }

            if (null != m_TurnOff)
            {
                try
                {
                    m_TurnOff.Dispose();
                }
                catch
                {

                }

                m_TurnOff = null;
            }

            m_Window = null;
        }

        private void Dispose(bool disposing)
        {
            this.CleanUpWakeLock();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}