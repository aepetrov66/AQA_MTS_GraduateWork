using CoreProject.Clients;
using CoreProject.Helpers;
using CoreProject.Helpers.Configuration;
using CoreProject.Models;
using RestSharp;
using System.Net;
using System.Text.Json;
using TechTalk.SpecFlow.Assist;

namespace CoreProject.Services;

public class ProjectService : IProjectService, IDisposable
{
    private readonly RestClientExtended _client;

    public ProjectService(RestClientExtended client)
    {
        _client = client;
    }

    public Response<Projects> GetProjects()
    {
        var request = new RestRequest("project").AddHeader("Token", Configurator.AppSettings.Token!);

        var projects = _client.Execute<Response<Projects>>(request);
        return projects.Data!;
    }

    public HttpStatusCode GetProjectBad(string projectId)
    {
        var request = new RestRequest("{project_id}").AddHeader("Token", Configurator.AppSettings.Token!)
            .AddUrlSegment("project_id", projectId);

        var projects = _client.Execute<Response<Projects>>(request);
        return projects.StatusCode;
    }

    public Response<Project> GetProject(string projectId)
    {
        var request = new RestRequest("project/{project_id}").AddHeader("Token", Configurator.AppSettings.Token!)
            .AddUrlSegment("project_id", projectId);

        return _client.Execute<Response<Project>>(request).Data!;
    }

    public Response<Project> AddProject(Dictionary<string, object> json)
    {
        var request = new RestRequest("project", Method.Post).AddHeader("Token", Configurator.AppSettings.Token!)
            .AddJsonBody(JsonSerializer.Serialize(json));

        return _client.Execute<Response<Project>>(request).Data!;
    }

    public HttpStatusCode DeleteProject(string projectCode)
    {
        var request = new RestRequest("project/{projectCode}", Method.Delete).AddHeader("Token", Configurator.AppSettings.Token!)
            .AddUrlSegment("projectCode", projectCode);
        return _client.Execute(request).StatusCode;
    }

    public HttpStatusCode Unauthorized()
    {
        var request = new RestRequest("project");

        return _client.Execute(request).StatusCode;
    }

    public void Dispose()
    {
        _client?.Dispose();
        GC.SuppressFinalize(this);
    }
}