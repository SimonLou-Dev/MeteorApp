using System.Reactive.Disposables;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using MeteorApp.Utils;
using ReactiveUI;
using SkiaSharp;

namespace MeteorApp.ViewModels;

public class ViewModelBase : ObservableObject
{

    public IBrush NeuBackground { get; set; } = getIbrushFromColor(NeuColors.Background);
    public IBrush NeuBackgroundVar { get; set; } = getIbrushFromColor(NeuColors.BackgroundVar);
    public IBrush NeuPrimary { get; set; } = getIbrushFromColor(NeuColors.Primary);
    public IBrush NeuPrimaryVar { get; set; } = getIbrushFromColor(NeuColors.PrimaryVar);
    public IBrush NeuSecondary { get; set; } = getIbrushFromColor(NeuColors.Secondary);
    public IBrush NeuSecondaryVar { get; set; } = getIbrushFromColor(NeuColors.SecondaryVar);
    public IBrush NeuRed { get; set; } = getIbrushFromColor(NeuColors.Red);
    public IBrush NeuDarkBlue { get; set; } = getIbrushFromColor(NeuColors.DarkBlue);
    public IBrush NeuGreen { get; set; } = getIbrushFromColor(NeuColors.Green);


    private static IBrush getIbrushFromColor(SKColor color)
    {
        return new SolidColorBrush(new Color(color.Alpha, color.Red, color.Green, color.Blue));
    }




}
