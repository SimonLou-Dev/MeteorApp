using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace MeteorApp.ViewModels;


public partial class MainWindowViewModel : ObservableObject
{

    private readonly ViewModelBase[] Pages =
    {
        new WelcomeViewModel(),
        new OverviewViewModel(),
    };

    [ObservableProperty]
    private ViewModelBase _currentPage;

    [RelayCommand]
    public void NavigateOverview()
    {
        Console.WriteLine("Clicked");
        CurrentPage = Pages[1];

    }



    public MainWindowViewModel()
    {
        CurrentPage = Pages[0];

    }

}

