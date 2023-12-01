﻿using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using MeteorApp.ViewModels;
using ReactiveUI;

namespace MeteorApp.Views;

public partial class OverviewView : UserControl
{



    public OverviewView()
    {
        this.InitializeComponent();
        DataContext = new OverviewViewModel();
    }

    private void AttachDevTools()
    {

    }
}