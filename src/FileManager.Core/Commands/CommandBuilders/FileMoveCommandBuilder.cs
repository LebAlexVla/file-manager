using FileManager.Core.Errors;

namespace FileManager.Core.Commands.CommandBuilders;

public class FileMoveCommandBuilder : ICommandBuilder
{
    private string? _sourcePath;
    private string? _destinationPath;

    public FileMoveCommandBuilder WithSourcePath(string path)
    {
        _sourcePath = path;

        return this;
    }

    public FileMoveCommandBuilder WithDestinationPath(string path)
    {
        _destinationPath = path;

        return this;
    }

    public CommandBuildResult Build()
    {
        if (_sourcePath is null || _destinationPath is null)
        {
            return new CommandBuildResult.Failure(
                new BuildingError("You must call WithSourcePath or WithDestinationPath first"));
        }

        return new CommandBuildResult.Success(new FileMoveCommand(_sourcePath, _destinationPath));
    }
}