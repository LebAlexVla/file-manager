using FileManager.Core.Commands.CommandsAdditions.TreeDrawing.FileSystemComponents;

namespace FileManager.Core.Commands.CommandsAdditions.TreeDrawing.FileSystemComponentVisitors;

public interface IFileSystemComponentVisitor
{
    void Visit(FileFileSystemComponent component);

    void Visit(DirectoryFileSystemComponent component);
}