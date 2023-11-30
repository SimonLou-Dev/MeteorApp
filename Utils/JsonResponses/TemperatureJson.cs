using System.Collections.Generic;

namespace MeteorApp.Utils.JsonResponses;

public class TemperatureJson
{
    public double latitude { get; set; }
    public double longitude { get; set; }
    public double generationtime_ms { get; set; }
    public double utc_offset_seconds { get; set; }
    public string timezone { get; set; }
    public string timezone_abbreviation { get; set; }
    public HourlyJson hourly { get; set; }
    public double elevation { get; set; }
}

public class HourlyJson
{
    public double[] temperature_2m { get; set; }
    public string[] time { get; set; }
}

