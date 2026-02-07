using FileManager.Core.Errors;

namespace FileManager.Core.Commands.CommandBuilders;

public class FileCopyCommandBuilder : ICommandBuilder
{
    private string? _sourcePath;
    private string? _destinationPath;

    public FileCopyCommandBuilder WithSourcePath(string path)
    {
        _sourcePath = path;

        return this;
    }

    public FileCopyCommandBuilder WithDestinationPath(string path)
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

        return new CommandBuildResult.Success(new FileCopyCommand(_sourcePath, _destinationPath));
    }
}