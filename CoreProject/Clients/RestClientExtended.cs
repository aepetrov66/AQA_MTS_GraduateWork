using CoreProject.Helpers.Configuration;
using CoreProject.Models;
using NUnit.Framework.Internal;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Authenticators.OAuth2;
using System.Diagnostics;

namespace CoreProject.Clients;

public sealed class RestClientExtended
{
    private readonly RestClient _client;

    public RestClientExtended()
    {
        var options = new RestClientOptions(Configurator.AppSettings.URI ?? throw new InvalidOperationException());
        _client = new RestClient(options);
    }

    public void Dispose()
    {
        _client?.Dispose();
        GC.SuppressFinalize(this);
    }

    public RestResponse Execute(RestRequest request)
    {
        var response = _client.Execute(request);

        return response;
    }

    public RestResponse<T> Execute<T>(RestRequest request)
    {
        var response = _client.Execute<T>(request);

        return response ?? throw new InvalidOperationException();
    }
}