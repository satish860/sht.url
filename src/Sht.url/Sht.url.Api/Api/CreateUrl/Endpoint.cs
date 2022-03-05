using FastEndpoints;

namespace Sht.url.Api.Api.CreateUrl
{
    public class Endpoint : Endpoint<CreateShortUrl,CreateShortUrlResponse>
    {
        public override void Configure()
        {
            Post("/links");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CreateShortUrl req, CancellationToken ct)
        {
            await SendAsync(new CreateShortUrlResponse
            {
                Url = req.Url,
            });
        }
    }
}
