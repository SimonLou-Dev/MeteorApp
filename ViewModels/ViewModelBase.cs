using System.Reactive.Disposables;
using ReactiveUI;

namespace MeteorApp.ViewModels;

public class ViewModelBase : ReactiveObject, IActivatableViewModel
{
    public ViewModelActivator Activator { get; }

    public ViewModelBase()
    {
        Activator = new ViewModelActivator();
        this.WhenActivated((CompositeDisposable disposables) =>
        {
            Disposable
                .Create(() => { })
                .DisposeWith(disposables);
        });
    }
}
