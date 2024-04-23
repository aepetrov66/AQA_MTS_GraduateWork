using CoreProject.Clients;
using CoreProject.Helpers.Configuration;
using CoreProject.Models;
using RestSharp;
using System.Net;
using System.Text.Json;

namespace CoreProject.Services;

public class TestCaseService
{
    private readonly RestClientExtended _client;

    public TestCaseService(RestClientExtended client)
    {
        _client = client;
    }
    public HttpStatusCode DeleteProject(string projectCode, int id)
    {
        var request = new RestRequest("case/{projectCode}/{id}", Method.Delete).AddHeader("Token", Configurator.AppSettings.Token!)
            .AddUrlSegment("projectCode", projectCode).AddUrlSegment("id", id);
        return _client.Execute(request).StatusCode;
    }

    public HttpStatusCode AddTestCase(string projectCode, Dictionary<string, object> json)
    {
        var request = new RestRequest("case/{code}", Method.Post).AddHeader("Token", Configurator.AppSettings.Token!)
            .AddUrlSegment("code", projectCode)
            .AddJsonBody(JsonSerializer.Serialize(json));

        return _client.Execute(request).StatusCode;
    }

    public void Dispose()
    {
        _client?.Dispose();
        GC.SuppressFinalize(this);
    }
}