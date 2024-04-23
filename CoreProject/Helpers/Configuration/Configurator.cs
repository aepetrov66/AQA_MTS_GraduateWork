using CoreProject.Models.Enums;
using CoreProject.Models;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace CoreProject.Helpers.Configuration;

public static class Configurator
{
    private static readonly Lazy<IConfiguration> s_configuration;
    public static IConfiguration Configuration => s_configuration.Value;

    static Configurator()
    {
        s_configuration = new Lazy<IConfiguration>(BuildConfiguration);
    }

    private static IConfiguration BuildConfiguration()
    {
        var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var builder = new ConfigurationBuilder()
            .SetBasePath(basePath ?? throw new InvalidOperationException())
            .AddJsonFile("appsettings.json");

        var appSettingFiles = Directory.EnumerateFiles(basePath ?? string.Empty, "appsettings.*.json");

        foreach (var appSettingFile in appSettingFiles)
        {
            builder.AddJsonFile(appSettingFile);
        }

        return builder.Build();
    }

    public static AppSettings AppSettings
    {
        get
        {
            var appSettings = new AppSettings();
            var child = Configuration.GetSection("AppSettings");

            appSettings.URL = child["URL"];
            appSettings.URI = child["URI"];
            appSettings.Token = child["Token"];
            appSettings.Username = child["Username"];
            appSettings.Password = child["Password"];

            return appSettings;
        }
    }

    public static List<User?> Users
    {
        get
        {
            List<User?> users = new();
            var child = Configuration.GetSection("Users");
            foreach (var section in child.GetChildren())
            {
                var user = new User
                {
                    Password = section["Password"]!,
                    Username = section["Username"]!
                };
                user.UserType = section["UserType"]!.ToLower() switch
                {
                    "correct" => UserType.Correct,
                    "incorrect" => UserType.Incorrect,
                    _ => user.UserType
                };

                users.Add(user);
            }

            return users;
        }
    }

    public static User? CorrectUser => Users.Find(x => x?.UserType == UserType.Correct);
    public static User? IncorrectUser => Users.Find(x => x?.UserType == UserType.Incorrect);
    public static string? Token => Configuration[nameof(Token)];
    public static string? BrowserType => Configuration[nameof(BrowserType)];
    public static double WaitsTimeout => Double.Parse(Configuration[nameof(WaitsTimeout)]!);
}
