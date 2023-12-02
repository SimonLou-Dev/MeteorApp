using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reactive;
using Avalonia;
using Avalonia.Themes.Neumorphism;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.Kernel;
using LiveChartsCore.Kernel.Sketches;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Extensions;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.VisualElements;
using LiveChartsCore.VisualElements;
using MeteorApp.Models;
using MeteorApp.Utils;
using ReactiveUI;
using SkiaSharp;

namespace MeteorApp.ViewModels;

public partial class OverviewViewModel : ViewModelBase
{


    public NeuColors NeuColors { get; set; } = new NeuColors();


    private readonly Random _random = new();

    private ObservableValue _temperatureValue;
    private ObservableValue _precipitationValue;
    private ObservableValue _windValue;

    [ObservableProperty] public double _initialTempRotation = 0;

    [ObservableProperty] public int _minTempValue = 0;
    [ObservableProperty] public double _maxTempValue = 80;
    [ObservableProperty] private bool _negativetemp =  false;

    [ObservableProperty] private double _currentTemp = 0;
    [ObservableProperty] private double _currentPrecipitation = 0;



    public ObservableCollection<PieSeries<ObservableValue>> TempSeries { get; set; }
    public ObservableCollection<PieSeries<ObservableValue>> PrecipirationSeries { get; set; }
    public ObservableCollection<PieSeries<ObservableValue>> WindSeries { get; set; }






    public LabelVisual TemperatureTitle { get; set; } =
        new LabelVisual
        {
            Text = "Température",
            TextSize = 22,
            Paint = new SolidColorPaint(NeuColors.Secondary)
        };

    public LabelVisual PrecipitationTitle { get; set; } =
        new LabelVisual
        {
            Text = "Précipitation",
            TextSize = 22,
            Paint = new SolidColorPaint(NeuColors.Secondary)
        };

    public LabelVisual WindTitle { get; set; } =
        new LabelVisual
        {
            Text = "Vitesse et direction du vent",
            TextSize = 22,
            Paint = new SolidColorPaint(NeuColors.Secondary)
        };








    public OverviewViewModel()
    {

        _temperatureValue = new ObservableValue(-20);
        _precipitationValue = new ObservableValue(100);
        _windValue = new ObservableValue(0);

        PrecipirationSeries = GaugeGenerator.BuildSolidGauge(
            new GaugeItem(_precipitationValue, series =>
            {
                series.Fill = new LinearGradientPaint(
                    new [] { NeuColors.Green, NeuColors.DarkBlue },
                    new SKPoint(0,0),
                    new SKPoint(1,0)
                    );
                series.MaxRadialColumnWidth = 50;
                series.DataLabelsFormatter = x => CurrentPrecipitation + "%";
                series.Stroke = null;
                series.DataLabelsSize = 40;
                series.DataLabelsPaint = new SolidColorPaint(NeuColors.Tertiary);
            })
        );

        TempSeries = GaugeGenerator.BuildSolidGauge(
            new GaugeItem(_temperatureValue, series =>
            {
                series.Fill = new LinearGradientPaint(
                    new [] { NeuColors.DarkBlue, NeuColors.Red },
                    new SKPoint(0,0.4f),
                    new SKPoint(1.5f,0.4f)
                    );
                series.MaxRadialColumnWidth = 50;
                series.DataLabelsSize = 40;
                series.DataLabelsPaint = new SolidColorPaint(NeuColors.Tertiary);
                series.DataLabelsFormatter = x => CurrentTemp + "°C";
                series.InnerRadius = 70;


            })
        );






        reloadApi();




    }



    [RelayCommand]
    public void reloadApi()
    {

        CurrentWeatherModel currentWeatherModel = new CurrentWeatherModel().loadFromApi(48.6844, 6.185);

        double Originaltemp = currentWeatherModel.temperature;
        double temp = Originaltemp;
        CurrentTemp = temp;
        if (temp <= -20) temp = -20;
        if (temp > 40) temp = 40;

        temp = Math.Abs(temp);

        _temperatureValue.Value = Math.Abs(temp);
        if (Originaltemp >= 0.0)
        {
            Negativetemp = false;
            InitialTempRotation = -90;
            MinTempValue = 0;
            MaxTempValue = 160;
        }
        else
        {
            Negativetemp = true;
            InitialTempRotation = -90 - (Math.Abs(temp) * 90 / 20); //119
            MinTempValue = 0;
            MaxTempValue = 80;
        }




        _currentPrecipitation = currentWeatherModel.precipiration;
        _precipitationValue.Value = _currentPrecipitation;
        //temperatures.temperature.ToList().ForEach(x => _temperatureValues.Add(new ObservableValue(x)));


    }



}