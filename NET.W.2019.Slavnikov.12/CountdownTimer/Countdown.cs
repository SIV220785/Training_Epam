using System;
using System.Threading;

namespace Countdown.DLL
{
    public class Countdown
    {
        public delegate void CountdownHandler(object sender, CountdownEventArgs e);

        public event CountdownHandler CountdownTimer;

        public void StartCountdown(int seconds, string message)
        {
            if (seconds <= 0)
            {
                throw new ArgumentException(nameof(seconds));
            }
            Thread.Sleep(seconds * 1000);
            OnCountdownTimer(this, new CountdownEventArgs(seconds, message));
        }
        protected virtual void OnCountdownTimer(object sender, CountdownEventArgs e) => CountdownTimer?.Invoke(sender, e);
    }
}
