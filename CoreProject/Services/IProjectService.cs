using CoreProject.Models;
using System.Net;

namespace CoreProject.Services;

public interface IProjectService
{
    Response<Project> GetProject(string projectId);
    Response<Projects> GetProjects();
    Response<Project> AddProject(Dictionary<string, object> json);
}