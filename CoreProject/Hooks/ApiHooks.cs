using CoreProject.Clients;
using CoreProject.Core;
using CoreProject.Helpers.Configuration;
using CoreProject.Services;

namespace CoreProject.Hooks;

[Binding]
public class ApiHook
{
    protected ProjectService? _projectService;

    public ApiHook(ProjectService ProjectService)
    {
        
    }

}
