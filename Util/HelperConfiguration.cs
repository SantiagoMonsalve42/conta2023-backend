
using Microsoft.Extensions.Configuration;

namespace Common.Utilities
{
    public class HelperConfiguration
    {
        public static IConfiguration Configuration { get; set; }

         public static string GetParam(string Key)
         {
             return Configuration[Key] ?? "";
         }

         public async Task<string> GetParamAsync(string Key)
         {
             return await Task.FromResult(GetParam(Key));
         }
    }
}
