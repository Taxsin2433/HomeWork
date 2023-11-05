using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Добавьте сервисы в контейнер.
builder.Services.AddDbContext<EFCoreContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(EFCoreContext))));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<EFCoreContext>();
    context.Database.Migrate();
}

// Добавьте настройку JSON и JSON Secret, если они отсутствуют.

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
