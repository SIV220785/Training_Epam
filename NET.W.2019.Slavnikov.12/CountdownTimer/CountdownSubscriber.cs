using System;

namespace Countdown.DLL
{
    /// <summary>
    /// Class that subscribes for Coundown.
    /// </summary>
    public class CountdownSubscriber
    {
        /// <summary>
        /// Subscribing for event.
        /// </summary>
        /// <param name="countdown"> Instance of Countdown.</param>
        public void Register(Countdown countdown)
        {
            if (countdown is null)
            {
                throw new ArgumentNullException(nameof(countdown));
            }

            countdown.CountdownTimer += this.Countdown_CountdownTimer;
        }

        /// <summary>
        /// Unsubscribing for event.
        /// </summary>
        /// <param name="countdown"> Instance of Countdown</param>
        public void Unregister(Countdown countdown)
        {
            if (countdown is null)
            {
                throw new ArgumentNullException(nameof(countdown));
            }

            countdown.CountdownTimer -= this.Countdown_CountdownTimer;
        }

        private void Countdown_CountdownTimer(object sender, CountdownEventArgs e)
        {
            Console.WriteLine("Countdown ended!");
            Console.WriteLine($"The message is: {e.Message}");
        }
    }
}
