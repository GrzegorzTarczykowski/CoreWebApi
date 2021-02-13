namespace CoreWebApi.Models
{
    public class ApplicationSettings
    {
        public const string ApplicationSettingsSection = "ApplicationSettings";
        public string JWT_Secret { get; set; }
        public string Client_URL { get; set; }
    }
}
