using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.JavaScript;
using System.Text.Json;
using MeteorApp.Services;
using MeteorApp.Utils;
using MeteorApp.Utils.JsonResponses;

namespace MeteorApp.Models;

public class TemperatureModel
{

    public double[] temperature { get; set; }
    public string[] dateTime { get; set; }

    public int numberOfValue = 0;


    public TemperatureModel loadFromApi(double lat, double lon, int forecast_days = 3)
    {
        this.numberOfValue = forecast_days * 24;

        this.temperature = new double[this.numberOfValue];
        this.dateTime = new string[this.numberOfValue];

        Dictionary<string, string> parameters = new Dictionary<string, string>();
        parameters.Add("latitude",  NumberUtils.doubleToString(lat));
        parameters.Add("longitude",  NumberUtils.doubleToString(lat));
        parameters.Add("hourly", "temperature_2m");
        parameters.Add("forecast_days", forecast_days.ToString());

        string JsonRslt = ApiServices.getAsyncWeatherApi(parameters).Result;

        TemperatureJson? temperatureJson = JsonSerializer.Deserialize<TemperatureJson>(JsonRslt);

        int arrayLength = temperatureJson.hourly.temperature_2m.Length;


        for (int i = 0; i < arrayLength; i++)
        {

            this.temperature[i] = (double) temperatureJson.hourly.temperature_2m[i];
            this.dateTime[i] = DateTime.Parse(temperatureJson.hourly.time[i]).ToString("dd HH:mm");


        }

        return this;
    }



}