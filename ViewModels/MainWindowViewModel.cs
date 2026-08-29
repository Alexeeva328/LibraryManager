using System.Reactive;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using ViewModelServices.Common;

namespace ViewModels;

public class MainWindowViewModel : BaseViewModel, IScreen
{
    public RoutingState Router { get; } = new();
    public IScreen HostScreen { get; set; }
    private readonly IThemeService _themeService;

    [Reactive] public bool IsDarkTheme { get; set; }

    [Reactive] public string CurrentThemeName { get; set; }

    public ReactiveCommand<Unit, Unit> ToggleThemeCommand { get; set; }
    public ReactiveCommand<Unit, Unit> CycleThemeCommand { get; set; }

   
    public MainWindowViewModel(IThemeService themeService)
    {
        _themeService = themeService;
        UpdateThemeState(_themeService.CurrentCustomTheme);
        
        ToggleThemeCommand = ReactiveCommand.Create(ToggleTheme);
        CycleThemeCommand = ReactiveCommand.Create(CycleTheme);
        
        // Подписываемся на изменения темы
        _themeService.ThemeChanged += (_, theme) =>
        {
            UpdateThemeState(theme);
        };
    }

    private void UpdateThemeState(CustomTheme customTheme)
    {
        IsDarkTheme = customTheme == CustomTheme.Dark;
        CurrentThemeName = customTheme switch
        {
            CustomTheme.Light => "☀️ Светлая",
            CustomTheme.Dark => "🌙 Тёмная",
            CustomTheme.Pink => "🌸 Розовая",
            CustomTheme.Mint => "🌿 Мятная",
            _ => "📱 Системная"
        };
    }

    private void ToggleTheme()
    {
        _themeService.ToggleTheme();
    }

    private void CycleTheme()
    {
        _themeService.CycleTheme();
    }
}