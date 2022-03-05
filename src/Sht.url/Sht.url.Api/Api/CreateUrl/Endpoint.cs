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
            var slug = await Nanoid.Nanoid.GenerateAsync("0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ", 12);
            await SendAsync(new CreateShortUrlResponse
            {
                ShortUrl = $"{_httpContext.Request.Scheme}://{_httpContext.Request.Host}/{slug}",
                Url = req.Url,
            }) ;
        }
    }
}
