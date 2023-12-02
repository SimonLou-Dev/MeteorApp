using System;
using System.Collections.Generic;
using System.Text.Json;
using CommunityToolkit.Mvvm.ComponentModel;
using MeteorApp.Services;
using MeteorApp.Utils;
using MeteorApp.Utils.JsonResponses;

namespace MeteorApp.Models;

public class CurrentWeatherModel
{

    public double temperature { get; set; }
    public double precipiration { get; set; }

    public double windForce { get; set; }
    public double windDirection { get; set; }





    public CurrentWeatherModel loadFromApi(double lat, double lon)
    {

        this.temperature = 0;
        this.precipiration = 0;
        this.windForce = 0;
        this.windDirection = 0;


        Dictionary<string, string> parameters = new Dictionary<string, string>();
        parameters.Add("latitude",  NumberUtils.doubleToString(lat));
        parameters.Add("longitude",  NumberUtils.doubleToString(lat));
        parameters.Add("current", "temperature_2m,precipitation,wind_speed_10m,wind_direction_10m");

        string JsonRslt = ApiServices.getAsyncWeatherApi(parameters).Result;


        CurrentWeatherJson? weatherParams = JsonSerializer.Deserialize<CurrentWeatherJson>(JsonRslt);

        this.temperature = weatherParams.current.temperature_2m;
        this.precipiration = weatherParams.current.precipitation;
        this.windForce = weatherParams.current.wind_speed_10m;
        this.windDirection = weatherParams.current.wind_direction_10m;

        return this;
    }


}