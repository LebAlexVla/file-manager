namespace FileManager.Core.FileSystems;

public interface IFileSystem
{
    string RootPath { get; }

    string UpdatePath(string currentPath, string path);

    string? GetDirectoryName(string path);

    string? GetFileName(string path);

    string? ReadFile(string path);
}