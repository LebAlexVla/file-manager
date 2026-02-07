namespace FileManager.Core.FileSystems;

public interface IFileSystem
{
    string RootPath { get; }

    string UpdatePath(string currentPath, string path);

    string? GetDirectoryName(string path);

    string? GetFileName(string path);

    IEnumerable<string> EnumerateDirectories(string path);

    IEnumerable<string> EnumerateFiles(string path);

    string? ReadFile(string path);
}