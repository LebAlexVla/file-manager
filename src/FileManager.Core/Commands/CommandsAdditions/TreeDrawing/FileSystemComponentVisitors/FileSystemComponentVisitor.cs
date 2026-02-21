using FileManager.Core.Commands.CommandsAdditions.TreeDrawing.FileSystemComponents;
using FileManager.Core.Commands.CommandsAdditions.TreeDrawing.TreeAssembler;

namespace FileManager.Core.Commands.CommandsAdditions.TreeDrawing.FileSystemComponentVisitors;

public class FileSystemComponentVisitor : IFileSystemComponentVisitor
{
    private readonly ITreeDrawAssembler _treeAssembler;
    private int _depth;

    public FileSystemComponentVisitor(int depth, ITreeDrawAssembler treeAssembler)
    {
        _depth = depth;
        _treeAssembler = treeAssembler;
    }

    public void Visit(FileFileSystemComponent file)
    {
        _treeAssembler.AssembleFile(file.Name, _depth);
    }

    public void Visit(DirectoryFileSystemComponent directory)
    {
        _treeAssembler.AssembleDirectory(directory.Name, _depth);

        if (_depth <= 0)
        {
            return;
        }

        IEnumerable<IFileSystemComponent> children = directory.EnumerateChildren();
        _depth--;
        foreach (IFileSystemComponent child in children)
        {
            child.Accept(this);
        }

        _depth++;
    }
}