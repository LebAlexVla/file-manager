using FileManager.Core.Errors;

namespace FileManager.Core.Commands.CommandBuilders;

public class FileRenameCommandBuilder : ICommandBuilder
{
    private string? _path;
    private string? _name;

    public FileRenameCommandBuilder WithPath(string path)
    {
        _path = path;

        return this;
    }

    public FileRenameCommandBuilder WithName(string name)
    {
        _name = name;

        return this;
    }

    public CommandBuildResult Build()
    {
        if (_path is null || _name is null)
        {
            return new CommandBuildResult.Failure(
                new BuildingError("You must call WithPath or WithName first"));
        }

        return new CommandBuildResult.Success(new FileRenameCommand(_path, _name));
    }
}