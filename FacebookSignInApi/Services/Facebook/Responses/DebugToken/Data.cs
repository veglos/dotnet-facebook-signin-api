using System.Collections.Generic;

namespace FacebookSignInApi.Services.Facebook.Responses.DebugToken
{
    public class Data
    {
        public Data()
        {
            scopes = new List<string>();
        }

        public string app_id { get; set; }
        public string type { get; set; }
        public string application { get; set; }
        public long data_access_expires_at { get; set; }
        public long expires_at { get; set; }
        public bool is_valid { get; set; }
        public IList<string> scopes { get; set; }
        public string user_id { get; set; }
    }
}
