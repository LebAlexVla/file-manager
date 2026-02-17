namespace FileManager.Core.FileSystems;

public class LocalFileSystem : IFileSystem
{
    public LocalFileSystem(string rootPath)
    {
        RootPath = rootPath;
    }

    public string RootPath { get; }

    public bool FileExists(string path)
    {
        return File.Exists(path);
    }

    public bool DirectoryExists(string path)
    {
        return Directory.Exists(path);
    }

    public string UpdatePath(string currentPath, string path)
    {
        string newPath = path.StartsWith('/') ? path : Path.Combine(currentPath, path);

        newPath = Path.GetFullPath(Path.Combine(RootPath, newPath.TrimStart('/')));

        if (!newPath.StartsWith(RootPath, StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException("cannot navigate outside of connection root.");
        }

        return newPath;
    }

    public string? GetDirectoryName(string path)
    {
        return Path.GetDirectoryName(path);
    }

    public string? GetFileName(string path)
    {
        return Path.GetFileName(path);
    }

    public IEnumerable<string> EnumerateDirectories(string path)
    {
        return Directory.EnumerateDirectories(path);
    }

    public IEnumerable<string> EnumerateFiles(string path)
    {
        return Directory.EnumerateFiles(path);
    }

    public string? ReadFile(string path)
    {
        return File.Exists(path) ? File.ReadAllText(path) : null;
    }

    public void MoveFile(string sourcePath, string destinationPath)
    {
        File.Move(sourcePath, destinationPath);
    }

    public void CopyFile(string sourcePath, string destinationPath)
    {
        File.Copy(sourcePath, destinationPath);
    }

    public void DeleteFile(string path)
    {
        File.Delete(path);
    }

    public void RenameFile(string path, string name)
    {
        string? directory = Path.GetDirectoryName(path);
        if (directory == null)
        {
            throw new DirectoryNotFoundException();
        }

        string newPath = Path.Combine(directory, name);

        File.Move(path, newPath);
    }
}