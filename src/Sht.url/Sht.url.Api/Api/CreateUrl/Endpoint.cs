using FastEndpoints;
using Microsoft.Extensions.Caching.Distributed;

namespace Sht.url.Api.Api.CreateUrl
{
    public class Endpoint : Endpoint<CreateShortUrl,CreateShortUrlResponse>
    {
        private readonly IDistributedCache distributedCache;

        public Endpoint(IDistributedCache distributedCache)
        {
            this.distributedCache = distributedCache;
        }

        public override void Configure()
        {
            Post("/links");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CreateShortUrl req, CancellationToken ct)
        {
            var slug = await Nanoid.Nanoid.GenerateAsync("0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ", 12);
            var shortUrl = $"{BaseURL}{slug}";
            await this.distributedCache.SetStringAsync(slug, req.Url);
            await SendAsync(new CreateShortUrlResponse
            {
                ShortUrl = shortUrl,
                Url = req.Url,
            }) ;
        }
    }
}
