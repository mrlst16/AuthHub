namespace AuthHub.Models.Options
{
    public class EmailServiceOptions
    {
        public string ServerAddress { get; set; }
        public int Port { get; set; }
        public string FromEmail { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }

        public EmailServiceOptions()
        {
        }
    }
}
