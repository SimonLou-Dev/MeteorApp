using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using MeteorApp.ViewModels;

namespace MeteorApp.Views;

public partial class WelcomeView : UserControl
{



    public WelcomeView()
    {
        InitializeComponent();
        DataContext = new WelcomeViewModel();
    }


    private void AttachDevTools()
    {

    }
}