using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace MeteorApp.Services;

public class ApiServices
{
    protected string GeoApiKey = "";

    static HttpClient client = new HttpClient();


    protected Task<HttpResponseMessage> getAsyncGeoApi(string endpoint, Dictionary<string, string> parameters)
    {
        var builder = new UriBuilder("https://api.geoapify.com/v1/geocode" + endpoint);
        var query = HttpUtility.ParseQueryString(builder.Query);
        query["key"] = GeoApiKey;
        foreach (var parameter in parameters)
        {
            query[parameter.Key] = parameter.Value;
        }
        builder.Query = query.ToString();
        string url = builder.ToString();
        return client.GetAsync(url);
    }

    protected Task<HttpResponseMessage> getAsyncWeatherApi(string endpoint, Dictionary<string, string> parameters)
    {
        var builder = new UriBuilder("https://api.openweathermap.org/data/2.5/weather");
        var query = HttpUtility.ParseQueryString(builder.Query);
        query["appid"] = GeoApiKey;
        foreach (var parameter in parameters)
        {
            query[parameter.Key] = parameter.Value;
        }
        builder.Query = query.ToString();
        string url = builder.ToString();
        return client.GetAsync(url);
    }




}