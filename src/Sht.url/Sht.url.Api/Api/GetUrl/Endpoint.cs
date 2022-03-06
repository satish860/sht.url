using FastEndpoints;
using Microsoft.Extensions.Caching.Distributed;

namespace Sht.url.Api.Api.GetUrl
{
    public class Endpoint : Endpoint<GetRequest>
    {
        private readonly IDistributedCache distributedCache;

        public Endpoint(IDistributedCache distributedCache)
        {
            this.distributedCache = distributedCache;
        }

        public override void Configure()
        {
            Get("/{slug}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(GetRequest req, CancellationToken ct)
        {
            var url = await this.distributedCache.GetStringAsync(req.Slug, ct);
            if (url == null)
            {
                await SendNotFoundAsync(ct);
            }
            else
            {
                await SendRedirectAsync(url, true, ct);
            }

        }
    }
}
