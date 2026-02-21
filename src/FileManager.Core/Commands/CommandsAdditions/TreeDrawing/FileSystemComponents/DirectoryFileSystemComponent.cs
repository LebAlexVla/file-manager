using FileManager.Core.Commands.CommandsAdditions.TreeDrawing.FileSystemComponentVisitors;
using FileManager.Core.FileSystems;

namespace FileManager.Core.Commands.CommandsAdditions.TreeDrawing.FileSystemComponents;

public class DirectoryFileSystemComponent : IFileSystemComponent
{
    private readonly IFileSystem _fileSystem;

    public DirectoryFileSystemComponent(string name, string path, IFileSystem fileSystem)
    {
        Name = name;
        Path = path;
        _fileSystem = fileSystem;
    }

    public string Path { get; }

    public string Name { get; }

    public void Accept(IFileSystemComponentVisitor visitor)
    {
        visitor.Visit(this);
    }

    public IEnumerable<IFileSystemComponent> EnumerateChildren()
    {
        foreach (string directory in _fileSystem.EnumerateDirectories(Path))
        {
            string? name = _fileSystem.GetFileName(directory);
            if (name != null)
            {
                yield return new DirectoryFileSystemComponent(name, directory, _fileSystem);
            }
        }

        foreach (string file in _fileSystem.EnumerateFiles(Path))
        {
            string? name = _fileSystem.GetFileName(file);
            if (name != null)
            {
                yield return new FileFileSystemComponent(name, file);
            }
        }
    }
}