using FastEndpoints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddFastEndpoints();
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetValue<string>("Redis:ConnectionString");
});
var app = builder.Build();

app.MapGet("/", () => "Welcome to Sht.url");
app.UseFastEndpoints();

app.Run();
