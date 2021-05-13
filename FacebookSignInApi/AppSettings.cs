namespace FacebookSignInApi
{
    public class AppSettings
    {
        public FacebookSettings FacebookSettings { get; set; }
    }

    public class FacebookSettings
    {
        public string AppID { get; set; }
        public string AppSecret { get; set; }
    }
}
