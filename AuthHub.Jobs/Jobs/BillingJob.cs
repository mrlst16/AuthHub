using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hangfire;

namespace AuthHub.Jobs.Jobs
{
    public class BillingJob
    {
        public static void Run()
        {
            BackgroundJob.Enqueue(() => Console.WriteLine($"The current date in UTC is {DateTime.UtcNow}"));
        }

        public void RunThis(string jobName)
        {

        }
    }
}
