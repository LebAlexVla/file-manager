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
        string newPath = UpdatePath(path, name);
        File.Move(path, newPath);
    }
}