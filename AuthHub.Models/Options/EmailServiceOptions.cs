namespace AuthHub.Models.Options
{
    public class EmailServiceOptions
    {
        public string ServerAddress { get; set; }
        public int Port { get; set; }
        public string FromEmail { get; set; }
        public string Password { get; set; }
        public object HostUrl { get; set; }

        public EmailServiceOptions()
        {
        }
    }
}
