

using System.Configuration;

namespace DDD.Domain
{
    public static class Shared
    {
        public static bool IsFake { get; } = ConfigurationManager.AppSettings["IsFake"] == "1";
        
        public static string FakePath { get; } = ConfigurationManager.AppSettings["FakePath"];

        public static string LoginId { get; set; } = string.Empty;
    }
}
