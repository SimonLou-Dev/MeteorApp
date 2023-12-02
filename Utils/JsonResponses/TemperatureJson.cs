using System.Collections.Generic;

namespace MeteorApp.Utils.JsonResponses;

public class TemperatureJson : BaseJson
{

    public HourlyJson hourly { get; set; }
    public double elevation { get; set; }
}

public class HourlyJson
{
    public double[] temperature_2m { get; set; }
    public string[] time { get; set; }
}

