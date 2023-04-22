using Order.Contracts;
using Order.Entities;
using Microsoft.EntityFrameworkCore;
using Order.Repository;
using Order.Service.IService;
using Order.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<OrderContext>(opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection"), b => b.MigrationsAssembly("Order")));
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());    

var app = builder.Build();

app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(configure: endpoints =>
{
    endpoints.MapControllers();
});

app.Run();