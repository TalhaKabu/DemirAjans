using Kab.DemirAjans.Business.DependencyResolver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Resolve(builder.Configuration);

builder.Services.AddCors(options => options.AddPolicy(name: "DemirAjans",
    policy =>
    {
        policy.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader();
    }));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("DemirAjans");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
