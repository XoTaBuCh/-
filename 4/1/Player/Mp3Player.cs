using System;
using System.Text;
using System.Runtime.InteropServices;

namespace Player
{
    class Mp3Player
    {
        public Mp3Player()
        {
        }

        public bool paused;

        private int volume;
        public int Volume
        {
            get
            {
                return volume;
            }
            set
            {
                int t = value;
                if (value < 0)
                {
                    t = 0;
                }
                else if (value > 100)
                {
                    t = 100;
                }
                volume = t;
                t *= 10;
                string command = "setaudio MediaFile volume to " + t.ToString();
                mciSendString(command, null, 0, IntPtr.Zero);
            }
        }

        public bool Path(string fileName)
        {
            Stop();
            string command = "open \"" + fileName + "\" alias MediaFile";
            if (!mciSendString(command, null, 0, IntPtr.Zero).Equals(0))
            {
                return false;
            }
            command = "play MediaFile";
            if (!mciSendString(command, null, 0, IntPtr.Zero).Equals(0))
            {
                Stop();
                return false;
            }
            Volume = 50;
            paused = false;
            return true;
        }

        public void Pause()
        {
            string command = (paused ? "resume" : "pause") + " MediaFile";
            mciSendString(command, null, 0, IntPtr.Zero);
            paused = !paused;
        }

        public void Stop()
        {
            paused = true;
            string command = "stop MediaFile";
            mciSendString(command, null, 0, IntPtr.Zero);
            command = "close MediaFile";
            mciSendString(command, null, 0, IntPtr.Zero);
        }

        [DllImport("winmm.dll")]
        private static extern int mciSendString(string strCommand,
            StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);
    }
}