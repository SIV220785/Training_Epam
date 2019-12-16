using System;
using System.Threading;

namespace Countdown.DLL
{
    /// <summary>
    /// Class-event for countdown when it's over.
    /// </summary>
    public class Countdown
    {
        /// <summary>
        /// Delegate for handling event.
        /// </summary>
        /// <param name="sender">Name of event broadcaster.</param>
        /// <param name="e">Information about event.</param>
        public delegate void CountdownEventHandler(object sender, CountdownEventArgs e);

        /// <summary>
        /// Event.
        /// </summary>
        public event CountdownEventHandler CountdownTimer;

        /// <summary>
        /// Method that initiates event and sends information in it.
        /// </summary>
        /// <param name="seconds"> Time in seconds.</param>
        /// <param name="message"> Message.</param>
        public void StartCountdown(int seconds, string message)
        {
            if (seconds <= 0)
            {
                throw new ArgumentException("seconds < 1");
            }

            Thread.Sleep(seconds * 1000);
            this.OnCountdownTimer(this, new CountdownEventArgs(seconds, message));
        }

        /// <summary>
        /// Virtual event trigger method.
        /// </summary>
        /// <param name="sender">Name of event broadcaster.</param>
        /// <param name="e">Information about event.</param>
        protected virtual void OnCountdownTimer(object sender, CountdownEventArgs e) => this.CountdownTimer?.Invoke(sender, e);
    }
}
