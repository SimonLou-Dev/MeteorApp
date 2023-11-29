using System.Reactive;
using ReactiveUI;

namespace MeteorApp.ViewModels;

public class MainWindowViewModel : ViewModelBase, IScreen
{

    public RoutingState Router { get; } = new RoutingState();

    public ReactiveCommand<Unit, IRoutableViewModel> NavigateOverview { get; }

    public MainWindowViewModel()
    {
        NavigateOverview = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new OverviewViewModel(this)));
    }


    public string Greeting => "Welcome to Avalonia!";
}
