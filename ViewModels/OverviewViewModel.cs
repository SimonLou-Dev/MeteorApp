using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.VisualElements;
using LiveChartsCore.VisualElements;
using MeteorApp.Models;
using ReactiveUI;
using SkiaSharp;

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

    public ReactiveCommand<Unit, Unit> reloadApi { get; }



    public ISeries[] _TempSeries =
    {
        new LineSeries<double>
        {
            Values = new double[] { 2, 1, 3, 5, 3, 4, 6 },
            Name = "Temperature",

            Fill = null
        }
    };

    public ISeries[] TempSeries
    {
        get => _TempSeries;
        set => this.RaiseAndSetIfChanged(ref _TempSeries, value);
    }

    public Axis[] _TodayXAxes  =
    {
        new Axis()
        {
            Name = "Heure",
            Labels = new string[] { "00h", "01h", "02h", "03h", "04h", "05h", "06h", "07h" }
        }
    };

    public Axis[] TodayXAxes
    {
        get => _TodayXAxes;
        set => this.RaiseAndSetIfChanged(ref _TodayXAxes, value);
    }

    public LabelVisual TempTitle { get; set; } =
        new LabelVisual
        {
            Text = "Prévision température de la journée",
            TextSize = 25,
            Padding = new LiveChartsCore.Drawing.Padding(15),
            Paint = new SolidColorPaint(SKColors.DarkSlateGray)
        };


    public OverviewViewModel()
    {

        Console.WriteLine("C'est tout bon");

        reloadApi = ReactiveCommand.Create(refreshApi);
        TemperatureModel Temperatures = new TemperatureModel().loadFromApi(52.52, 13.41);
        TempSeries.SetValue(new LineSeries<double>
        {
            Values = new double[] { 12, 1, 30, 5, 3, 4, 6 },
            Name = "Temperature",

            Fill = null
        }, 0);







    }

    public void refreshApi()
    {
        Console.WriteLine("Call");



        Console.WriteLine("After");
    }



}