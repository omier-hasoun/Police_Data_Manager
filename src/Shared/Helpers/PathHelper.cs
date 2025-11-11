namespace Shared.Helpers;

public static class PathHelper
{
    public static string GetSolutionRootPath()
    {
        var currentDirectory = AppContext.BaseDirectory;
        var directoryInfo = new DirectoryInfo(currentDirectory);

        while (directoryInfo != null && !directoryInfo.GetFiles(".sln").Any())
        {
            directoryInfo = directoryInfo.Parent;
        }

        if (directoryInfo == null)
        {
            throw new DirectoryNotFoundException("Solution root path could not be found.");
        }

        return directoryInfo.FullName;
    }

    public static string GetEnvFilePath()
    {
        var currentDirectory = AppContext.BaseDirectory;
        var directoryInfo = new DirectoryInfo(currentDirectory);

        while (directoryInfo != null && !directoryInfo.GetFiles(".env").Any())
        {
            directoryInfo = directoryInfo.Parent;
        }

        if (directoryInfo == null)
        {
            throw new DirectoryNotFoundException(".env root path could not be found.");
        }

        return Path.Combine(directoryInfo.FullName, ".env");
    }
}
