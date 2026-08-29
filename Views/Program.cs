using Avalonia;
using System;
using System.IO;
using System.Threading.Tasks;
using Avalonia.ReactiveUI;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services.Title;
using Serilog;

namespace Views;

internal sealed class Program
{
    private static IServiceProvider? _serviceProvider;

    public static async Task<int> Main(string[] args)
    {
        try
        {
            Log.Information("Launching application");

            var host = Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, builder) =>
                {
                    builder.SetBasePath(AppContext.BaseDirectory)
                        .AddJsonFile("appsettings.json", false, true)
                        .AddEnvironmentVariables()
                        .AddCommandLine(args);
                })
                .UseSerilog((context, services, loggerConfiguration) =>
                {
                    // Читаем конфигурацию Serilog из загруженной конфигурации
                    loggerConfiguration
                        .ReadFrom.Configuration(context.Configuration)
                        .Enrich.FromLogContext();
                })
                .ConfigureServices((context, services) =>
                {
                    var connectionString = context.Configuration.GetConnectionString("DefaultConnection");
                    if (!string.IsNullOrEmpty(connectionString))
                    {
                        services.AddDbContext<ApplicationDbContext>(options =>
                            options.UseNpgsql(connectionString));
                        services.AddDbContextFactory<ApplicationDbContext>(options =>
                            options.UseNpgsql(connectionString));
                    }

                    ConfigureServices(services);
                })
                .Build();
            _serviceProvider = host.Services;

            using (var scope = host.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                await dbContext.Database.MigrateAsync();
            }
            
            BuildAvaloniaApp(host)
                .StartWithClassicDesktopLifetime(args);

            Log.Information("Application completed successfully.");
            return 0;
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Application terminated with a critical error.");
            return 1;
        }
        finally
        {
            await Log.CloseAndFlushAsync();
        }
    }

    public static AppBuilder BuildAvaloniaApp(IHost host)
    {
        return AppBuilder.Configure(() => new App(host))
            .UsePlatformDetect()
            .LogToTrace()
            .WithInterFont()
            .UseReactiveUI();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        // Регистрируем сервисы
        services.AddSingleton<ITitleService, TitleService>();

        services.AddTransient<ViewModels.MainWindowViewModel>();
        services.AddTransient<LibraryManager.MainWindow>();
    }
}