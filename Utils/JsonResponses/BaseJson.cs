namespace MeteorApp.Utils.JsonResponses;

public class BaseJson
{
    public double latitude { get; set; }
    public double longitude { get; set; }
    public double generationtime_ms { get; set; }
    public double utc_offset_seconds { get; set; }
    public string timezone { get; set; }
    public string timezone_abbreviation { get; set; }
}