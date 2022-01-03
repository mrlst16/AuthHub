namespace AuthHub.DAL.Sql
{
    public static class SprocNames
    {
        //Save sprocs
        public const string SaveUser = "usp_SaveUser";
        public const string SaveAuthSettings = "usp_SaveAuthSettings";
        public const string SaveOrganization = "usp_SaveOrganization";
        public const string SavePassword = "usp_SavePassword";
        public const string SavePasswordResetToken = "usp_SavePasswordResetToken";

        //Get Sprocs
        public const string GetAuthSettings = "usp_GetAuthSettings";
        public const string GetOrganization = "usp_GetUser";
        public const string GetUser = "usp_GetUser";
        public const string GetPassword = "usp_GetPassword";
        public const string GetPasswordResetToken = "usp_GetPasswordResetToken";
    }
}
