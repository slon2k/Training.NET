using System;
using System.Threading;
using Tasks.Delegates;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {

            // Delegates. Lambdas and Events. Task 3. 
            // Countdown demo. 
            var timer = new Countdown();
            var messageService = new MessageService();
            var mailService = new MailService();
            timer.TimeElapsed += messageService.OnTimeElapsed;
            timer.TimeElapsed += mailService.OnTimeElapsed;
            timer.Start(3000);
        }
    }
}
