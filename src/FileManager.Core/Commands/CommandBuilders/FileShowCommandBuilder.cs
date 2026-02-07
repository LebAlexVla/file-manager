using FileManager.Core.Commands.CommandsAdditions.Writing;
using FileManager.Core.Errors;

namespace FileManager.Core.Commands.CommandBuilders;

public class FileShowCommandBuilder : ICommandBuilder
{
    private IWriter? _writer;
    private string? _path;

    public FileShowCommandBuilder WithPath(string path)
    {
        _path = path;

        return this;
    }

    public FileShowCommandBuilder WithFileWriter(IWriter writer)
    {
        _writer = writer;

        return this;
    }

    public CommandBuildResult Build()
    {
        if (_writer is null || _path is null)
        {
            return new CommandBuildResult.Failure(
                new BuildingError("You must call WithPath or WithFileWriter first"));
        }

        return new CommandBuildResult.Success(new FileShowCommand(_writer, _path));
    }
}