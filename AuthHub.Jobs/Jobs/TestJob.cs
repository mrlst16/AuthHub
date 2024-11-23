namespace AuthHub.Jobs.Jobs
{
    public class TestJob
    {

        public static void Run()
        {
            Console.WriteLine($"Test Job, the date and time in UTC are {DateTime.UtcNow}");
        }
    }
}
