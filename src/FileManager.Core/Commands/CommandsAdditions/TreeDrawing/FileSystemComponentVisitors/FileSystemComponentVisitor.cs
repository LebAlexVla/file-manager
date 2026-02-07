using FileManager.Core.Commands.CommandsAdditions.TreeDrawing.FileSystemComponents;
using FileManager.Core.Commands.CommandsAdditions.TreeDrawing.TreeAssembler;
using FileManager.Core.FileSystems;

namespace FileManager.Core.Commands.CommandsAdditions.TreeDrawing.FileSystemComponentVisitors;

public class FileSystemComponentVisitor : IFileSystemComponentVisitor
{
    private readonly ITreeAssembler _treeAssembler;
    private readonly IFileSystem _fileSystem;
    private int _depth;

    public FileSystemComponentVisitor(int depth, IFileSystem fileSystem, ITreeAssembler treeAssembler)
    {
        _depth = depth;
        _fileSystem = fileSystem;
        _treeAssembler = treeAssembler;
    }

    public void Visit(FileFileSystemComponent component)
    {
        _treeAssembler.AssembleFile(component.Name, _depth);
    }

    public void Visit(DirectoryFileSystemComponent component)
    {
        _treeAssembler.AssembleDirectory(component.Name, _depth);

        IEnumerable<string> directories = _fileSystem.EnumerateDirectories(component.Path);
        IEnumerable<string> files = _fileSystem.EnumerateFiles(component.Path);

        if (_depth > 0)
        {
            _depth--;
            foreach (string directory in directories)
            {
                string? newDirectoryName = _fileSystem.GetDirectoryName(directory);
                if (newDirectoryName != null)
                {
                    var newDirectory = new DirectoryFileSystemComponent(newDirectoryName, directory);
                    Visit(newDirectory);
                }
            }

            _depth++;

            foreach (string file in files)
            {
                string? newFileName = _fileSystem.GetFileName(file);
                if (newFileName != null)
                {
                    var newFile = new FileFileSystemComponent(newFileName, file);
                    Visit(newFile);
                }
            }
        }
    }
}