var builder = WebApplication.CreateBuilder(args);

// PORT (keep this)
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(int.Parse(port));
});

// Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ✅ FORCE Swagger
app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ScoreCards API");
    c.RoutePrefix = "swagger"; // important
});



app.UseAuthorization();

app.MapControllers();

// Test route
app.MapGet("/", () => "API Running...");

app.Run();