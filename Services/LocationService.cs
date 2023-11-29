using System;
using System.Collections.Generic;

namespace MeteorApp.Services;

public class LocationService : ApiServices
{

    //TOdo make Throwable
    public string autoDetectLocation(string search)
    {

        string result = "";
        this.getAsyncGeoApi("/autocomplete", new Dictionary<string, string> {
            { "text", search },
            { "lang", "fr" },
            { "limit", "5" },
            { "type", "city" },
            {"format", "json"}
        }).ContinueWith(async responseTask =>
        {
            var response = await responseTask;
            result = await response.Content.ReadAsStringAsync();

        });

        return result;


    }

    public string getGeoCoords(string location)
    {
        string result = "";
        this.getAsyncGeoApi("/search", new Dictionary<string, string> {
            { "text", location },
            { "lang", "fr" },
            { "limit", "1" },
            { "type", "city" },
            {"format", "json"}
        }).ContinueWith(async responseTask =>
        {
            var response = await responseTask;
            result = await response.Content.ReadAsStringAsync();

        });

        return result;

    }






}