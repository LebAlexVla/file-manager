using FileManager.Core.Errors;

namespace FileManager.Core.Commands.CommandBuilders;

public class FileDeleteCommandBuilder : ICommandBuilder
{
    private string? _path;

    public FileDeleteCommandBuilder WithPath(string path)
    {
        _path = path;

        return this;
    }

    public CommandBuildResult Build()
    {
        if (_path is null)
        {
            return new CommandBuildResult.Failure(
                new BuildingError("You must call WithPath first"));
        }

        return new CommandBuildResult.Success(new FileDeleteCommand(_path));
    }
}