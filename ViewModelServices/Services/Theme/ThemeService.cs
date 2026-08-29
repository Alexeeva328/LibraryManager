using ViewModelServices.Common;

public class ThemeService : IThemeService
{
    private CustomTheme _currentCustomTheme;
    public event EventHandler<CustomTheme> ThemeChanged;

    public CustomTheme CurrentCustomTheme => _currentCustomTheme;

    private readonly List<CustomTheme> _themeCycle = new()
    {
        CustomTheme.Light,
        CustomTheme.Dark,
        CustomTheme.Pink,
        CustomTheme.Mint
    };

    public ThemeService()
    {
        // Просто устанавливаем тему по умолчанию - Light
        _currentCustomTheme = CustomTheme.Light;
    }

    public void SetTheme(CustomTheme customTheme)
    {
        if (_currentCustomTheme == customTheme) return;

        _currentCustomTheme = customTheme;
        ThemeChanged?.Invoke(this, customTheme);
    }

    public void ToggleTheme()
    {
        // Переключаем между Light и Dark
        var newTheme = _currentCustomTheme == CustomTheme.Dark
            ? CustomTheme.Light
            : CustomTheme.Dark;
        SetTheme(newTheme);
    }

    public void CycleTheme()
    {
        // Циклическое переключение по всем темам
        var currentIndex = _themeCycle.IndexOf(_currentCustomTheme);
        var nextIndex = (currentIndex + 1) % _themeCycle.Count;
        SetTheme(_themeCycle[nextIndex]);
    }
}