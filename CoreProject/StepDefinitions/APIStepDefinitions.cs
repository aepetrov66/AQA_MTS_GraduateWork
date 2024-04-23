using CoreProject.Clients;
using CoreProject.Models;
using CoreProject.Services;
using NLog;
using NUnit.Framework;
using NUnit.Framework.Internal;
using RestSharp;
using System.Net;
using TechTalk.SpecFlow.Analytics.AppInsights;
using Logger = NLog.Logger;

namespace CoreProject.StepDefinitions;

[Binding]
public class APIStepDefinitions : BaseApiStep
{
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();


    [Given(@"I send a GET request to the endpoint")]
    public void GivenISendAGETRequestToTheEndpoint()
    {
        var response = ProjectService!.GetProjects();
        Assert.Multiple(() =>
        {
            Assert.That(response.Result.Count == response.Result.Entities.Count());
            Assert.That(response.Result.Entities.Select(x => x.Code.Equals("DEMO")).First());
        });
    }

    [Given(@"I send a GET request")]
    public void GivenISendAGETRequest()
    {
        var response = ProjectService!.GetProject("DEMO");
        Assert.That(response.Result.Title.Equals("Demo Project"));
    }

    [Given(@"I send a GET")]
    public void GivenISendAGET()
    {
        var response = ProjectService!.Unauthorized();
        Assert.That(response.Equals(HttpStatusCode.Unauthorized));
    }

    [Given(@"I seedfsfsdf")]
    public void GivenISeedfsfsdf()
    {
        var response = ProjectService!.GetProject("DEMOd");
        Assert.That(!response.Status);
        Assert.That(response.ErrorMessage.Equals("Project not found"));
    }

    [Given(@"I sasdfasdf")]
    public void GivenISasdfasdf()
    {
        Dictionary<string, object> json = new Dictionary<string, object>();
        json.Add("title", "dfsdfsdf");
        json.Add("code", "asdfasdfasdfasdfasdf");
        

        var response = ProjectService!.AddProject(json);

        Assert.That(!response.Status);
        Assert.That(response.ErrorMessage.Equals("Data is invalid."));
    }

    [Given(@"I seeasdfaasdf")]
    public void GivenISeeasdfaasdf()
    {
        Dictionary<string, object> json = new Dictionary<string, object>();
        json.Add("title", "dfsdfxxxsdf");
        json.Add("code", "xxxx");


        var response = ProjectService!.AddProject(json);

        Assert.That(response.Status);
        Assert.That(response.Result.Code.ToLower().Equals("xxxx"));
    }

}
