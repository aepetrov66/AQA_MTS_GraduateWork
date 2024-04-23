using CoreProject.Helpers.Configuration;
using CoreProject.Models.Enums;
using CoreProject.Models;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace CoreProject.Helpers;

public class TestData
{
    private static readonly Lazy<IConfiguration> td_configuration;
    public static IConfiguration TestDataConfiguration => td_configuration.Value;

    static TestData()
    {
        td_configuration = new Lazy<IConfiguration>(BuildConfiguration);
    }

    private static IConfiguration BuildConfiguration()
    {
        var assemblyPass = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        string filePath = Path.Combine(assemblyPass ?? throw new InvalidOperationException(), "Resources", "TestData");
        var builder = new ConfigurationBuilder()
            .SetBasePath(filePath!)
            .AddJsonFile("testData.json");

        var testDataFiles = Directory.EnumerateFiles(assemblyPass ?? string.Empty, "testData.*.json");

        foreach (var testDataFile in testDataFiles)
        {
            builder.AddJsonFile(testDataFile);
        }

        return builder.Build();
    }

    public static List<Project?> projects
    {
        get
        {
            List<Project?> projects = new();
            var child = TestDataConfiguration.GetSection("Projects");
            foreach (var section in child.GetChildren())
            {
                var project = new Project
                {
                    Title = section["title"]!,
                    Code = section["code"]!
                };
                project.testDataType = section["testDataType"]!.ToLower() switch
                {
                    "correct" => TestDataType.Correct,
                    "incorrect" => TestDataType.Incorrect,
                    _ => project.testDataType
                };

                projects.Add(project);
            }
            return projects;
        }
    }

    public static TestCase testCase
    {
        get
        {
            var testCase = new TestCase();
            var child = TestDataConfiguration.GetSection("Testcase");

            testCase.TestCaseTitle = child["testCaseTitle"];
            testCase.Status = child["status"];
            testCase.Description = child["description"];
            testCase.Suite = child["suite"];
            testCase.Severity = child["severity"];
            testCase.Priority = child["priority"];
            testCase.Type = child["type"];
            testCase.Layer = child["layer"];
            testCase.IsFlaky = child["isFlaky"];
            testCase.Milestone = child["milestone"];
            testCase.Behavior = child["behavior"];
            testCase.AutomationStatus = child["automationStatus"];

            return testCase;
        }
    }

    public static Project? CorrectProject => projects.Find(x => x?.testDataType == TestDataType.Correct);
    public static Project? IncorrectProject => projects.Find(x => x?.testDataType == TestDataType.Incorrect);
    public static TestCase? TestCase => testCase;
}
