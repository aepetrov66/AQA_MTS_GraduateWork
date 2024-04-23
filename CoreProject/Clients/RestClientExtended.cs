using CoreProject.Helpers.Configuration;
using CoreProject.Models;
using NLog;
using NUnit.Framework.Internal;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Authenticators.OAuth2;
using System.Diagnostics;
using Logger = NLog.Logger;

namespace CoreProject.Clients;

public sealed class RestClientExtended
{
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();
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

    private void LogRequest(RestRequest request)
    {
        _logger.Debug($"{request.Method} request to: {request.Resource}");

        var body = request.Parameters
            .FirstOrDefault(p => p.Type == ParameterType.RequestBody)?.Value;

        if (body != null)
        {
            _logger.Debug($"body: {body}");
        }
    }

    private void LogResponse(RestResponse response)
    {
        if (response.ErrorException != null)
        {
            _logger.Error(
                $"Error retrieving response. Check inner details for more info. \n{response.ErrorException.Message}");
        }

        _logger.Debug($"Request finished with status code: {response.StatusCode}");

        if (!string.IsNullOrEmpty(response.Content))
        {
            _logger.Debug(response.Content);
        }
    }

    public RestResponse Execute(RestRequest request)
    {
        LogRequest(request);
        var response = _client.Execute(request);
        LogResponse(response);

        return response;
    }

    public RestResponse<T> Execute<T>(RestRequest request)
    {
        LogRequest(request);
        var response = _client.Execute<T>(request);
        LogResponse(response);

        return response ?? throw new InvalidOperationException();
    }
}