namespace FileManager.Core.FileSystems;

public class LocalFileSystem : IFileSystem
{
    public LocalFileSystem(string rootPath)
    {
        RootPath = rootPath;
    }

    public string RootPath { get; }

    public string UpdatePath(string currentPath, string path)
    {
        string newPath = Path.IsPathFullyQualified(path)
            ? Path.Combine(RootPath, path.TrimStart(Path.DirectorySeparatorChar))
            : Path.GetFullPath(Path.Combine(currentPath, path));

        return newPath;
    }

    public string? GetDirectoryName(string path)
    {
        throw new NotImplementedException();
    }

    public string? GetFileName(string path)
    {
        throw new NotImplementedException();
    }

    public string? ReadFile(string path)
    {
        return File.Exists(path) ? File.ReadAllText(path) : null;
    }
}