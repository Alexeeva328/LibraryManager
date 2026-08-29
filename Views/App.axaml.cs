using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ViewModelServices.Common;

namespace Views;

public class App : Application
{
    public IHost _host;
    private IThemeService _themeService;

    public App()
    {
        _host = null;
    }

    public App(IHost host)
    {
        _host = host;
    }

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override async void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            _themeService = _host.Services.GetRequiredService<IThemeService>();
            // Запускаем хост
            await _host.StartAsync();

            var mainWindow = _host.Services.GetRequiredService<LibraryManager.MainWindow>();

            // Устанавливаем начальную тему
            ApplyTheme(_themeService.CurrentCustomTheme);

            // Подписываемся на изменения темы
            _themeService.ThemeChanged += OnThemeChanged;

            // Подписываемся на выход
            desktop.Exit += OnApplicationExit;

            desktop.MainWindow = mainWindow;
        }

        base.OnFrameworkInitializationCompleted();
    }

    private void OnThemeChanged(object sender, CustomTheme customTheme)
    {
        ApplyTheme(customTheme);
    }

    private void ApplyTheme(CustomTheme customTheme)
    {
        try
        {
            var themeName = customTheme switch
            {
                CustomTheme.Light => "Light",
                CustomTheme.Dark => "Dark",
                CustomTheme.Pink => "Pink",
                CustomTheme.Mint => "Mint",
                _ => "Light"
            };

            // Применяем тему ко всему приложению
            RequestedThemeVariant = new(themeName, ThemeVariant.Light);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error applying theme: {ex.Message}");
        }
    }

    private void OnApplicationExit(object sender, ControlledApplicationLifetimeExitEventArgs e)
    {
        if (_themeService != null)
        {
            _themeService.ThemeChanged -= OnThemeChanged;
        }

        try
        {
            _host?.StopAsync().Wait(TimeSpan.FromSeconds(5));
            _host?.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during shutdown: {ex.Message}");
        }
    }
}