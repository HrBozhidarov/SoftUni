namespace Sis.Http.Sessions
{
    using Contracts;
    using System.Collections.Concurrent;

    public class HttpSessionStorage
    {
        public const string SessionCookieKey = "SIS_ID";

        public const string SessionUserKey = "<%__User__Key__%>";

        private static readonly ConcurrentDictionary<string, IHttpSession> sessions
            = new ConcurrentDictionary<string, IHttpSession>();

        public static IHttpSession GetSession(string id)
        {
            return sessions.GetOrAdd(id, _ => new HttpSession(id));
        }
    }
}