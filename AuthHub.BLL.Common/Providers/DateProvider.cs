using Common.Interfaces.Providers;

namespace AuthHub.BLL.Common.Providers
{
    public class DateProvider : IDateProvider
    {
        public DateTime UTCNow { get; protected set; }

        public DateTime Now { get; protected set; }

        public DateProvider()
        {
            UTCNow = DateTime.UtcNow;
            Now = DateTime.Now;
        }

        public DateProvider(
            DateTime utcNow,
            DateTime now
            )
        {
            UTCNow = utcNow;
            Now = now;
        }
    }
}
