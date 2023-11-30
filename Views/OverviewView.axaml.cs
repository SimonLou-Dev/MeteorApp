using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using MeteorApp.ViewModels;
using ReactiveUI;

namespace MeteorApp.Views;

public partial class OverviewView : ReactiveUserControl<OverviewViewModel>
{



    public OverviewView()
    {
        this.WhenActivated(disposables =>
        { });
        AvaloniaXamlLoader.Load(this);
        this.InitializeComponent();
        DataContext = new OverviewViewModel();
    }

    private void AttachDevTools()
    {

    }
}