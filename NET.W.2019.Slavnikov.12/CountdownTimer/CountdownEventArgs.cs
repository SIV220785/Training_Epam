using System;

namespace Countdown.DLL
{
    public class CountdownEventArgs : EventArgs
    {
        public CountdownEventArgs(int seconds, string message)
        {
            this.Seconds = seconds;
            this.Message = message;
        }

        public string Message { get; }

        public int Seconds { get; }

    }
}