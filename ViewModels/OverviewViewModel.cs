using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reactive;
using Avalonia.Themes.Neumorphism;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.VisualElements;
using LiveChartsCore.VisualElements;
using MeteorApp.Models;
using ReactiveUI;
using SkiaSharp;

namespace MeteorApp.ViewModels;

public partial class OverviewViewModel : ViewModelBase
{


    private readonly Random _random = new();

    private ObservableCollection<ObservableValue> _temperatureValues;

    public ObservableCollection<ObservableValue> DateTimeValues;

    public ObservableCollection<ISeries> TempSeries { get; set; }

    public Axis[] DateTimeSeries { get; set; }


    public LabelVisual TempTitle { get; set; } =
        new LabelVisual
        {
            Text = "Prévision température des 72 prochaines heures",
            TextSize = 25,
            Paint = new SolidColorPaint(SKColors.DarkOrange)
        };

    public Axis[] YAxis { get; set; }



    public OverviewViewModel()
    {

        _temperatureValues = new ObservableCollection<ObservableValue>();

        TempSeries = new ObservableCollection<ISeries>
        {
            new LineSeries<ObservableValue>
            {
                Values = _temperatureValues,
                Name = "Temperature",
                Fill = new SolidColorPaint(SKColors.DarkSeaGreen),
                Stroke = null,
                GeometryFill = null,
                GeometryStroke = null
            }

        };

        string[] labels = new string[72];
        for (int i = 0; i < 72; i++)
        {
            labels[i] = DateTime.Now.AddHours(i).ToString("dd HH:mm");
        }



        DateTimeSeries = new Axis[]
        {
            new Axis
            {
                Labels = labels,

                LabelsPaint = new SolidColorPaint(SKColors.MediumPurple)
            }

        };

        YAxis = new Axis[]
        {
            new Axis
            {
                LabelsPaint = new SolidColorPaint(SKColors.MediumPurple)
            }

        };

        reloadApi();




    }
    [RelayCommand]
    public void reloadApi()
    {
        Console.WriteLine("Call");

        TemperatureModel temperatures = new TemperatureModel().loadFromApi(52.52, 13.41);
        temperatures.temperature.ToList().ForEach(x => _temperatureValues.Add(new ObservableValue(x)));









        Console.WriteLine("After");
    }



}