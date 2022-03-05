using FastEndpoints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddFastEndpoints();
var app = builder.Build();

app.MapGet("/", () => "Welcome to Sht.url");
app.UseFastEndpoints();

app.Run();
