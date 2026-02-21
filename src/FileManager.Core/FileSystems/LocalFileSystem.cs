using FileManager.Core.Errors;
using FileManager.Core.FileSystems.Results;

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

    public UpdatePathResult UpdatePath(string currentPath, string path)
    {
        string newPath;
        try
        {
            newPath = path.StartsWith('/') ? path : Path.Combine(currentPath, path);

            newPath = Path.GetFullPath(Path.Combine(RootPath, newPath.TrimStart('/')));
        }
        catch (Exception ex)
        {
            return new UpdatePathResult.Failure(new ExecutingError(ex.Message));
        }

        if (!newPath.StartsWith(RootPath, StringComparison.OrdinalIgnoreCase))
        {
            return new UpdatePathResult.Failure(
                new ExecutingError("Cannot navigate outside of connection root"));
        }

        return new UpdatePathResult.Success(newPath);
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

    public ReadFileResult ReadFile(string path)
    {
        string content;
        try
        {
            content = File.ReadAllText(path);
        }
        catch (Exception ex)
        {
            return new ReadFileResult.Failure(new ExecutingError(ex.Message));
        }

        return new ReadFileResult.Success(content);
    }

    public MoveFileResult MoveFile(string sourcePath, string destinationPath)
    {
        try
        {
            File.Move(sourcePath, destinationPath);
        }
        catch (Exception ex)
        {
            return new MoveFileResult.Failure(new ExecutingError(ex.Message));
        }

        return new MoveFileResult.Success();
    }

    public CopyFileResult CopyFile(string sourcePath, string destinationPath)
    {
        try
        {
            File.Copy(sourcePath, destinationPath);
        }
        catch (Exception ex)
        {
            return new CopyFileResult.Failure(new ExecutingError(ex.Message));
        }

        return new CopyFileResult.Success();
    }

    public DeleteFileResult DeleteFile(string path)
    {
        try
        {
            File.Delete(path);
        }
        catch (Exception ex)
        {
            return new DeleteFileResult.Failure(new ExecutingError(ex.Message));
        }

        return new DeleteFileResult.Success();
    }

    public RenameFileResult RenameFile(string path, string name)
    {
        string? directory = Path.GetDirectoryName(path);
        if (directory == null)
        {
            return new RenameFileResult.Failure(new ExecutingError("Directory not found"));
        }

        string newPath = Path.Combine(directory, name);

        try
        {
            File.Move(path, newPath);
        }
        catch (Exception ex)
        {
            return new RenameFileResult.Failure(new ExecutingError(ex.Message));
        }

        return new RenameFileResult.Success();
    }
}