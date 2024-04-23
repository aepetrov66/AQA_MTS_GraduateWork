using OpenQA.Selenium;

namespace CoreProject.Models;

public class TestCase
{
    public TestCase() { }
    public string TestCaseTitle { get; set; }
    public string Status { get; set; }
    public string Description { get; set; }
    public string Suite { get; set; }
    public string Severity { get; set; }
    public string Priority { get; set; }
    public string Type { get; set; }
    public string Layer { get; set; }
    public string IsFlaky { get; set; }
    public string Milestone { get; set; }
    public string Behavior { get; set; }
    public string AutomationStatus { get; set; }
}
