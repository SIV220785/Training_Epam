using System;

namespace Countdown.DLL
{
    /// <summary>
    /// Information, which is passed to the subscribers of the event notification.
    /// </summary>
    public class CountdownEventArgs : EventArgs
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="CountdownEventArgs"/> class.
        /// </summary>
        /// <param name="seconds"> Time in seconds.</param>
        /// <param name="message"> Message.</param>
        public CountdownEventArgs(int seconds, string message)
        {
            this.Seconds = seconds;
            this.Message = message;
        }

        /// <summary>
        /// Gets message.
        /// </summary>
        /// <value>
        /// Message.
        /// </value>
        public string Message { get; }

        /// <summary>
        /// Gets seconds.
        /// </summary>
        /// <value>
        /// Seconds.
        /// </value>
        public int Seconds { get; }

    }
}