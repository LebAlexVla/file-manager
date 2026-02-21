using FileManager.Core.FileSystems.Results;

namespace FileManager.Core.FileSystems;

public interface IFileSystem
{
    string RootPath { get; }

    bool FileExists(string path);

    bool DirectoryExists(string path);

    UpdatePathResult UpdatePath(string currentPath, string path);

    string? GetDirectoryName(string path);

    string? GetFileName(string path);

    IEnumerable<string> EnumerateDirectories(string path);

    IEnumerable<string> EnumerateFiles(string path);

    ReadFileResult ReadFile(string path);

    MoveFileResult MoveFile(string sourcePath, string destinationPath);

    CopyFileResult CopyFile(string sourcePath, string destinationPath);

    DeleteFileResult DeleteFile(string path);

    RenameFileResult RenameFile(string path, string name);
}