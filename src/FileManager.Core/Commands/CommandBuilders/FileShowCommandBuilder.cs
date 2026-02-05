using FileManager.Core.Commands.CommandsAdditions.FileShowing;
using FileManager.Core.Errors;

namespace FileManager.Core.Commands.CommandBuilders;

public class FileShowCommandBuilder : ICommandBuilder
{
    private IFileWriter? _fileWriter;
    private string? _path;

    public FileShowCommandBuilder WithPath(string path)
    {
        _path = path;

        return this;
    }

    public FileShowCommandBuilder WithFileWriter(IFileWriter fileWriter)
    {
        _fileWriter = fileWriter;

        return this;
    }

    public CommandBuildResult Build()
    {
        if (_fileWriter is null || _path is null)
        {
            return new CommandBuildResult.Failure(
                new BuildingError("You must call WithPath or WithFileWriter first"));
        }

        return new CommandBuildResult.Success(new FileShowCommand(_fileWriter, _path));
    }
}