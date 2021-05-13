namespace FacebookSignInApi.Models.Facebook.Requests
{
    public class FacebookSignInRequest
    {
        public string AccessToken { get; set; }
        public string UserID { get; set; }
        public int ExpiresIn { get; set; }
        public string SignedRequest { get; set; }
        public string GraphDomain { get; set; }
        public long DataAccessExpirationTime { get; set; }
    }
}
