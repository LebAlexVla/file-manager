using FileManager.Core.Errors;

namespace FileManager.Core.Commands.CommandBuilders;

public class TreeGotoCommandBuilder : ICommandBuilder
{
    private string? _path;

    public TreeGotoCommandBuilder WithPath(string path)
    {
        _path = path;

        return this;
    }

    public CommandBuildResult Build()
    {
        if (string.IsNullOrEmpty(_path))
        {
            return new CommandBuildResult.Failure(new BuildingError("Path cannot be null or empty"));
        }

        return new CommandBuildResult.Success(new TreeGotoCommand(_path));
    }
}