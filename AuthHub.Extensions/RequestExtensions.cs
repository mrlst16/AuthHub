using System;
using System.IO;
using System.Linq;

namespace AuthHub.Extensions
{
    public static class RequestExtensions
    {
        public static (string, string) DecodeBasicAuth(this string str)
        {
            try
            {
                string[] parts = str.Split(' ');
                string[] finalParts = null;
                var bytes = System.Convert.FromBase64String(parts.Last());
                using (var stream = new MemoryStream(bytes))
                using (var reader = new StreamReader(stream))
                {
                    var decoded = reader.ReadToEnd();
                    finalParts = decoded.Split(":");
                }
                return (finalParts.First(), finalParts.Last());
            }
            catch (Exception e)
            {
                return (null, null);
            }
        }
    }
}
