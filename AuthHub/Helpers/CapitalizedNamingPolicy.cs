using System.Linq;
using System.Text.Json;

namespace AuthHub.Api.Helpers
{
    public class CapitalizedNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name)
            => $"{name.ToUpper().First()}{name.Substring(1, name.Length - 1)}";
    }
}
