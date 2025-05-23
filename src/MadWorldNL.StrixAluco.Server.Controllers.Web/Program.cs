using MadWorldNL.StrixAluco.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddGrpcReflection();

builder.Services.AddCors(o => o.AddPolicy("AllowAll", policy =>
{
    policy.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
        .WithExposedHeaders("Grpc-Status", "Grpc-Message", "Grpc-Encoding", "Grpc-Accept-Encoding");
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseGrpcWeb(new GrpcWebOptions { DefaultEnabled = true });
app.UseCors();

app.MapGrpcService<GreeterService>()
    .RequireCors("AllowAll");

app.MapGet("/",
    () =>
        "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.MapGrpcReflectionService();

app.Run();