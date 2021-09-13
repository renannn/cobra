namespace Cobra.Core.Settings
{
    public class Tokens
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Key { get; set; }
        public short MinutesExpiration { get; set; }
        public short FinalExpiration { get; set; }
        public short RefreshTokenExpirationMinutes { get; set; }
    }
}
