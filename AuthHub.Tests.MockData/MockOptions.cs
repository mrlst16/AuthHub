using AuthHub.Models.Options;

namespace AuthHub.Tests.MockData
{
    public static class MockOptions
    {
        public static EmailServiceOptions EmailOptionsInstance { get; } = new EmailServiceOptions()
        {
            HostUrl = "email-smtp.us-east-2.amazonaws.com",
            ServerAddress = "smtp.gmail.com",
            FromEmail = "verifications@mattylantz.com",
            FromName = "AuthHub: Verification",
            Username = "AKIAW6KNALHHOIPJ5D27",
            Password = "BCKTgKGnZ8o3HzkrcHBNkWLNyTKTsmcnXmvoZ8fNGARA",
            Port = 587
        };
    }
}
