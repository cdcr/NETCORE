using Microsoft.EntityFrameworkCore;
using NetCore.Domain.Abstractions.Repository;
using NetCore.Domain.Abstractions.Service;
using NetCore.Domain.Entities;
using NetCore.Infraestructure.DataPersistence;
using NetCore.Infraestructure.DataPersistence.Repository;
using NetCore.Services.BusinessLogic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
SystemInfo systemInfo = new SystemInfo();
systemInfo.FillSettings();
builder.Services.AddSingleton<ISystemInfo>(systemInfo);

var optionsBuilder = new DbContextOptionsBuilder<UserContext>();
optionsBuilder.UseSqlServer(systemInfo.ConnectionString);
builder.Services.AddSingleton(optionsBuilder.Options);
builder.Services.AddDbContext<UserContext>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(options =>
{

    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

internal class SystemInfo : ISystemInfo
{
    public string ConnectionString { get; set; }
    public string Persistence { get; set; }
    public string DataBase { get; set; }

    IConfigurationRoot root;
    SystemInfo settings;
    private static void GetSettings(out IConfigurationRoot root, out SystemInfo settings)
    {
        IConfigurationBuilder builder = new ConfigurationBuilder();
        builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
        root = builder.Build();
        settings = root.GetSection("AppSettings").Get<SystemInfo>();
    }
    public void FillSettings()
    {
        GetSettings(out root, out settings);
        ConnectionString = root.GetConnectionString(settings.Persistence);
        DataBase = settings.DataBase;
        Persistence = settings.Persistence;
    }
}