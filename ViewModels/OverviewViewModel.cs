using ReactiveUI;

namespace MeteorApp.ViewModels;

public class OverviewViewModel :ViewModelBase, IRoutableViewModel
{
    public string? UrlPathSegment { get; }
    public IScreen HostScreen { get; }

    public OverviewViewModel(IScreen screen)
    {
        HostScreen = screen;
        UrlPathSegment = "Overview";
    }

}