using System;

namespace AuthHub.Tests.MockData
{
    public static class SharedMocks
    {
        public static byte[] Salt =>
            new byte[] {
                0,
                255,
                25,
                230,
                50,
                180,
                75,
                155
            };

        public static Guid TestOrganization1Id => Guid.Parse("618899E7-CA5B-4809-9D5F-64548C18FAD3");
        public static Guid AuthHubOrganization1Id => Guid.Parse("0B674AC4-7079-4AD7-830A-C41CD6AB5204");
    }
}
