using FileManager.Core.Commands.CommandsAdditions.TreeDrawing.FileSystemComponentVisitors;

namespace FileManager.Core.Commands.CommandsAdditions.TreeDrawing.FileSystemComponents;

public interface IFileSystemComponent
{
    string Path { get; }

    string Name { get; }

    void Accept(IFileSystemComponentVisitor visitor);
}