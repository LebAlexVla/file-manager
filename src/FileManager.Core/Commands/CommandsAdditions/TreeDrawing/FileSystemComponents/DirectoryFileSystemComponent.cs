using FileManager.Core.Commands.CommandsAdditions.TreeDrawing.FileSystemComponentVisitors;

namespace FileManager.Core.Commands.CommandsAdditions.TreeDrawing.FileSystemComponents;

public class DirectoryFileSystemComponent : IFileSystemComponent
{
    public DirectoryFileSystemComponent(string name, string path)
    {
        Name = name;
        Path = path;
    }

    public string Path { get; }

    public string Name { get; }

    public void Accept(IFileSystemComponentVisitor visitor)
    {
        visitor.Visit(this);
    }
}