namespace MeteorApp.Utils.JsonResponses;

public class CurrentWeatherJson : BaseJson
{

    public current current { get; set; }

}

public class current
{

    public string time { get; set; }
    public double temperature_2m { get; set; }
    public double precipitation { get; set; }
    public double wind_speed_10m { get; set; }
    public double wind_direction_10m { get; set; }
    public double interval { get; set; }

}