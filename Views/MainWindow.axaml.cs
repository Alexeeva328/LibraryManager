using Avalonia.ReactiveUI;
using ViewModels;

namespace LibraryManager;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();
    }
}