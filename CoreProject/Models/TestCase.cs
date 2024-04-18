using OpenQA.Selenium;

namespace CoreProject.Models;

public class TestCase
{
    public TestCase() { }
    public string NewTestCaseTitle { get; set; } = "Some Title";
    public string Status { get; set; } = "Draft";
    public string Description { get; set; } = "Some description";
    public string Suite { get; set; } = "Test cases without suite";
    public string Severity { get; set; } = "Normal";    
    public string Priority { get; set; } = "Medium";
    public string Type { get; set; } = "Regression";
    public string Layer { get; set; } = "Unit";
    public string IsFlaky { get; set; } = "No";
    public string Milestone { get; set; } = "Not set";
    public string Behavior { get; set; } = "Positive";
    public string AutomationStatus { get; set; } = "Manual";
}
