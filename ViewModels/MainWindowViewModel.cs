using ReactiveUI;

namespace ViewModels;

public class MainWindowViewModel : BaseViewModel, IScreen
{
    public RoutingState Router { get; } = new();
    public IScreen HostScreen { get; set; }
}