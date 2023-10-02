namespace FIlaVirtual.Util.Configuration
{
    public class TokenConfiguration
    {
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int AccessExpiration { get; set; }
        public int RefreshExpiration { get; set; }
        public bool IsExpiration { get; set; }
    }
}
