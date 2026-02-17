namespace FileManager.Core.FileSystems;

public interface IFileSystem
{
    string RootPath { get; }

    bool FileExists(string path);

    bool DirectoryExists(string path);

    string UpdatePath(string currentPath, string path);

    string? GetDirectoryName(string path);

    string? GetFileName(string path);

    IEnumerable<string> EnumerateDirectories(string path);

    IEnumerable<string> EnumerateFiles(string path);

    string? ReadFile(string path);

    void MoveFile(string sourcePath, string destinationPath);

    void CopyFile(string sourcePath, string destinationPath);

    void DeleteFile(string path);

    void RenameFile(string path, string name);
}