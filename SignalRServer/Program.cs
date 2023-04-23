using SignalRServer.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins("http://localhost:3000/")
                .AllowAnyHeader()
                .WithMethods("GET", "POST")
                .AllowCredentials();
        });
});

var app = builder.Build();

app.UseStaticFiles();
app.UseCors();

app.MapHub<ChatHub>("/hubs/chat");
app.MapHub<HealthCheckHub>("/health/check");

app.Run("http://localhost:5001");
