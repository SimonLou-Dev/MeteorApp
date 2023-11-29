using System;
using MeteorApp.ViewModels;
using MeteorApp.Views;
using ReactiveUI;

namespace MeteorApp;

public class AppViewLocator : ReactiveUI.IViewLocator
{
    public IViewFor? ResolveView<T>(T? viewModel, string? contract = null) =>
        viewModel switch
        {
            OverviewViewModel context => new OverviewView {DataContext = context},
            _ => throw new ArgumentException("Unknown ViewModel")
        };

}