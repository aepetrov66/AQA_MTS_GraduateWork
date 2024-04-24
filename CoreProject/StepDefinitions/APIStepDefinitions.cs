using CoreProject.Clients;
using CoreProject.Core;
using CoreProject.Helpers;
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
    private TestDataSteps _testDataSteps;
    public APIStepDefinitions(ScenarioContext scenarioContext, ProjectService projectService) : base(scenarioContext, projectService)
    {
        _testDataSteps = new TestDataSteps();
    }

    [Given(@"getProjects request to the endpoint")]
    public void GivenISendAGETRequestToTheEndpoint()
    {
        var response = ProjectService!.GetProjects();
        Assert.Multiple(() =>
        {
            Assert.That(response.Result.Count == response.Result.Entities.Count());
        });
    }

    [Given(@"getProject request to the endpoint")]
    public void GivenISendAGETRequest()
    {
        var response = ProjectService!.GetProject(TestData.CorrectProject.Code);
        Assert.That(response.Result.Title.Equals(TestData.CorrectProject.Title));
    }

    [Given(@"unauthorized request to the endpoint")]
    public void GivenISendAGET()
    {
        var response = ProjectService!.Unauthorized();
        Assert.That(response.Equals(HttpStatusCode.Unauthorized));
    }

    [Given(@"getUnexistingProject request to the endpoint")]
    public void GivenISeedfsfsdf()
    {
        var response = ProjectService!.GetProject(TestData.IncorrectProject.Code);
        Assert.That(!response.Status);
        Assert.That(response.ErrorMessage.Equals("Project not found"));
    }

    [Given(@"postProject with invalid data")]
    public void GivenISasdfasdf()
    {
        Dictionary<string, object> json = new Dictionary<string, object>();
        json.Add("title", TestData.IncorrectProject.Title);
        json.Add("code", TestData.IncorrectProject.Code);
        

        var response = ProjectService!.AddProject(json);

        Assert.That(!response.Status);
        Assert.That(response.ErrorMessage.Equals("Data is invalid."));
    }

    [Given(@"postProjectRequest to the endpoint")]
    public void GivenISeeasdfaasdf()
    {
        _testDataSteps.DeleteTestProject();
        Dictionary<string, object> json = new Dictionary<string, object>();
        json.Add("title", TestData.CorrectProject.Title);
        json.Add("code", TestData.CorrectProject.Code);


        var response = ProjectService!.AddProject(json);

        Assert.That(response.Status);
        Assert.That(response.Result.Code.ToLower().Equals(TestData.CorrectProject.Code.ToLower()));
    }

    [Given(@"getProject bad request to the endpoint")]
    public void GivenFasdfasdf()
    {
        var response = ProjectService!.GetProjectBad(TestData.IncorrectProject.Code);
        Assert.That(response.Equals(HttpStatusCode.NotFound));
    }

}
