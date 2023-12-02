using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.InteropServices.JavaScript;
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

    public static Task<String> getAsyncWeatherApi(Dictionary<string, string> parameters)
    {
        var builder = new UriBuilder("https://api.open-meteo.com/v1/forecast");
        parameters.Add("timezone","Europe/Berlin");

        string urlToCall = builder.ToString();


        foreach (var parameter in parameters)
        {
            if(urlToCall == builder.ToString())
            {
                urlToCall += "?";
            }
            else
            {
                urlToCall += "&";
            }

            if(parameter.Value == "latitude" || parameter.Value == "longitude")
            {
                urlToCall += parameter.Value + "=" + parameter.Key.Replace(",",".");
                continue;
            }

            urlToCall += parameter.Key + "=" + parameter.Value;

        }

        var response = client.GetAsync(urlToCall).Result;

        return  response.Content.ReadAsStringAsync();
    }




}