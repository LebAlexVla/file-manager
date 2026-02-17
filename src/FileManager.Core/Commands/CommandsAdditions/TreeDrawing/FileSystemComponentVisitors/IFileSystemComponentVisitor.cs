using FileManager.Core.Commands.CommandsAdditions.TreeDrawing.FileSystemComponents;

namespace FileManager.Core.Commands.CommandsAdditions.TreeDrawing.FileSystemComponentVisitors;

public interface IFileSystemComponentVisitor
{
    void Visit(FileFileSystemComponent file);

    void Visit(DirectoryFileSystemComponent directory);
}