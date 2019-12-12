using System;

namespace Countdown.DLL
{
    public class CountdownSubscriber
    {
        public void Register(Countdown countdown) => countdown.CountdownTimer += Countdown_CountdownTimer;

        public void Unregister(Countdown countdown) => countdown.CountdownTimer -= Countdown_CountdownTimer;

        private void Countdown_CountdownTimer(object sender, CountdownEventArgs e)
        {
            Console.WriteLine("Countdown ended!");
            Console.WriteLine($"The message is: {e.Message}");
        }
    }
}
