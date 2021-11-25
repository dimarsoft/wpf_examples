using AkaScan.EddyCurrent.Core.Logging;
using AkaScan.EddyCurrent.Core.Receiver;
using AkaScan.EddyCurrent.Core.Settings;
using Microsoft.Extensions.Logging;
using MvvmCross;
//using MvvmCross.Platform;
//using MvvmCross.Platform.Logging;
using System.Threading;

namespace AkaScan.EddyCurrent.Core.Base
{
    public abstract class ThreadWorker : IStartable
    {
        private bool _isStarted;
        private Thread _deviceWatchThread;
        private volatile bool _threadCheckDeviceTerminate;

        protected ILogger Log { get; }

        protected string Tag { get; }
        protected bool LogDetailed { get; }
        protected ThreadWorker()
        {
            Log = Mvx.IoCProvider.Resolve<ILogger>();

            Tag = GetType().Name;

            var settingsStorage = Mvx.IoCProvider.Resolve<ISettingsStorage>();

            LogDetailed = settingsStorage.GetItem<DebugSettings>(DebugSettings.Id).IsLogDetailed;
        }
        public virtual void Start()
        {
            if (_isStarted) return;

            if (LogDetailed) Log.DebugMessage(Tag, "thread Start()");

            _threadCheckDeviceTerminate = false;
            _stopEvent.Reset();
            _deviceWatchThread = new Thread(DeviceWatch) { Name = Tag };
            _deviceWatchThread.Start();
            _isStarted = true;
        }
        public virtual void Stop()
        {
            if (LogDetailed) Log.DebugMessage(Tag, "thread start to Stop()");
            _threadCheckDeviceTerminate = true;
            _stopEvent.Set();

            if (_deviceWatchThread != null && _deviceWatchThread.IsAlive)
            {
                _deviceWatchThread.Join();
            }

            _deviceWatchThread = null;

            _isStarted = false;

            if (LogDetailed) Log.DebugMessage(Tag, "thread stopped");

        }
        private readonly ManualResetEvent _stopEvent = new ManualResetEvent(false);
        /// <summary>
        /// Есть ли запрос остановки потока.
        /// </summary>
        protected bool IsStopping => _threadCheckDeviceTerminate;
        protected abstract void OnDoWork();
        private void DeviceWatch()
        {
            if (LogDetailed) Log.DebugMessage(Tag, "thread started");
            while (!_stopEvent.WaitOne(100))
            {
                OnDoWork();
            }
            if (LogDetailed) Log.DebugMessage(Tag, "thread finished");
        }
    }
}