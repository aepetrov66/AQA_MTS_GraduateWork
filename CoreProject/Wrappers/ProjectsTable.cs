using OpenQA.Selenium;

namespace CoreProject.Wrappers;

public class TableCell
{
    private UIElement _uiElement;
    private By ClickableElementBy = By.XPath(".//a[@class='cx2QU4']");

    public TableCell(UIElement uiElement)
    {
        _uiElement = uiElement;
    }

    public string Text => _uiElement.FindUIElement(ClickableElementBy).Text;
    public void Click() => _uiElement.FindUIElement(ClickableElementBy).Click();
}

public class TableRow
{
    private UIElement _uiElement;
    private List<TableCell> _cells;

    public TableRow(UIElement uiElement)
    {
        _uiElement = uiElement;
        _cells = new List<TableCell>();

        foreach (var cellElement in _uiElement.FindUIElements(By.TagName("td")))
        {
            _cells.Add(new TableCell(cellElement));
        }
    }
    public TableCell GetCell(int columnIndex)
    {
        return _cells[columnIndex];
    }
}

public class ProjectsTable
{
    private UIElement _uiElement;
    private List<UIElement> _columns;
    private List<TableRow> _rows;

    public ProjectsTable(IWebDriver webDriver, By by)
    {
        _uiElement = new UIElement(webDriver, by);
        _columns = new List<UIElement>();
        _rows = new List<TableRow>();

        foreach (var columnElement in _uiElement.FindUIElements(By.XPath(".//thead[@class='bAFuc9']/tr/child::node()")))
        {
            _columns.Add(columnElement);
        }

        foreach (var rowElement in _uiElement.FindUIElements(By.XPath(".//tbody[@class='YtumFo']/child::node()")))
        {
            _rows.Add(new TableRow(rowElement));
        }
    }

    public TableCell GetUpperProject()
    {
        TableRow tableRow = _rows[0];
        return tableRow.GetCell(2);
    }

    public TableCell GetProjectCell(string projectName)
    {
        foreach(var row in _rows)
        {
            if (row.GetCell(2).Text.Equals(projectName))
            {
                return row.GetCell(2);
            }
        }
        return null;
    }
}