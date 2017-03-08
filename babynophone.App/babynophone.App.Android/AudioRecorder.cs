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
    public class AudioRecorder : IAudioRecorder
    {
        public AudioRecorder()
        {
            m_MinSize = Android.Media.AudioRecord.GetMinBufferSize(SampleRate, Channelin, MediaEncoding);
        }

        ~AudioRecorder()
        {
            this.Dispose(false);
        }

        private volatile Android.Media.AudioRecord m_AudioRecord;
        private int m_MinSize;
        private const int SampleRate = 8000;
        private const Android.Media.ChannelIn Channelin = Android.Media.ChannelIn.Mono;
        private const Android.Media.Encoding MediaEncoding = Android.Media.Encoding.Pcm16bit;

        private Android.Media.AudioSource MediaAudioSource
        {
            get
            {
                return Android.Media.AudioSource.Default;                
            }
        }

        private object m_LockObj = new Object();


        public void Start()
        {
            lock (m_LockObj)
            {
                this.Initialize();
            }
        }

        private void Initialize()
        {
            if (IsStarted) return;

            try
            {
                m_AudioRecord = new Android.Media.AudioRecord(this.MediaAudioSource, SampleRate, Channelin, MediaEncoding, m_MinSize);
                m_AudioRecord.StartRecording();
            }
            catch
            {

            }
        }

        public void Stop()
        {
            lock (m_LockObj)
            {
                CleanUp();
            }
        }

        public bool IsStarted
        {
            get
            {
                return (null != m_AudioRecord);
            }
        }

        public int GetAmplitude()
        {
            lock (m_LockObj)
            {
                if (!IsStarted)
                {
                    return 0;
                }

                short[] buffer = new short[m_MinSize];
                m_AudioRecord.Read(buffer, 0, m_MinSize);
                int max = 0;
                foreach (short s in buffer)
                {
                    if (Math.Abs(s) > max)
                    {
                        max = Math.Abs(s);
                    }
                }

                if (0 == max)
                {
                    this.CleanUp();
                    this.Initialize();
                }

                return max;
            }
        }


        private void CleanUp()
        {
            if (null != m_AudioRecord)
            {
                try
                {
                    m_AudioRecord.Stop();
                    m_AudioRecord.Release();
                    m_AudioRecord.Dispose();
                }
                catch
                {

                }
                m_AudioRecord = null;
            }
        }

        private void Dispose(bool disposing)
        {
            CleanUp();
        }

        private bool m_SuppressFinalizeThis = true;

        public void Dispose()
        {
            bool alreadyDisposed = null == m_AudioRecord;
            this.Dispose(true);
            if (m_SuppressFinalizeThis)
            {
                m_SuppressFinalizeThis = false;
                GC.SuppressFinalize(this);
            }
        }

    }
}