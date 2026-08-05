using System.Reactive.Disposables;
using ReactiveUI;

namespace ViewModels;

public class BaseViewModel : ReactiveObject, IDisposable
{
    protected CompositeDisposable Disposables { get; } = new();

    protected bool IsDisposed { get; private set; }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (IsDisposed) return;
        if (disposing)
        {
            Disposables.Dispose();
        }

        IsDisposed = true;
    }
}