using Countdown.DLL;


namespace Console.PL
{
    using System;
    public class Program
    {
        public static void Main(string[] args)
        {
            Countdown.DLL.Countdown countdown = new Countdown.DLL.Countdown();
            CountdownSubscriber countdownSubscriber = new CountdownSubscriber();

            countdownSubscriber.Register(countdown);

            countdown.StartCountdown(10, "lya,lya");
            Console.WriteLine("++");
            Console.ReadKey();
        }
    }
}
