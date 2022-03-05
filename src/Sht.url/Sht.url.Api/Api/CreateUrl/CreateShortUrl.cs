using FastEndpoints.Validation;

namespace Sht.url.Api.Api.CreateUrl
{
    public class CreateShortUrl
    {
        public string Url { get; set; }
    }

    public class CreateUrlValidator:Validator<CreateShortUrl>
    {
        public CreateUrlValidator()
        {
            RuleFor(x => x.Url)
                .NotEmpty()
                .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _))
                .When(x => !string.IsNullOrEmpty(x.Url))
                .WithMessage("Url is not in correct format");
        }
    }
}
