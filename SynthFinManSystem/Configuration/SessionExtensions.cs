using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace SynthFinManSystem.Web.Configuration
{
    public static class SessionExtensions
    {
        public static void SetObject(this ISession session, string key, object value)
        {
            if (value == null)
            {
                session.Remove(key);
            }
            else
            {
                session.SetString(key, JsonConvert.SerializeObject(value));
            }

        }

        public static T GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
