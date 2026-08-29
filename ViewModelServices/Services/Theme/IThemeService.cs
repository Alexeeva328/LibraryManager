namespace ViewModelServices.Common;

public interface IThemeService
{
    event EventHandler<CustomTheme> ThemeChanged;
    CustomTheme CurrentCustomTheme { get; }
    void SetTheme(CustomTheme customTheme);
    void ToggleTheme();
    void CycleTheme();
}