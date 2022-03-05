namespace Sht.url.Api.Api.CreateUrl
{
    public class CreateShortUrlResponse
    {
        public string ShortUrl { get; set; } = string.Empty;

        public string Url { get; set; } = string.Empty ;

        public DateTime Expiry { get; set; } = DateTime.MinValue ;
    }
}
