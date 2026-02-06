using FileManager.Core.Commands.CommandsAdditions.TreeDrawing;
using FileManager.Core.Errors;

namespace FileManager.Core.Commands.CommandBuilders;

public class TreeListCommandBuilder : ICommandBuilder
{
    private IDrawer? _drawer;
    private string? _rawDepth;

    public TreeListCommandBuilder WithDrawer(IDrawer drawer)
    {
        _drawer = drawer;

        return this;
    }

    public TreeListCommandBuilder WithDepth(string rawDepth)
    {
        _rawDepth = rawDepth;

        return this;
    }

    public CommandBuildResult Build()
    {
        if (_drawer == null)
        {
            return new CommandBuildResult.Failure(
                new BuildingError("You must call WithDrawer first"));
        }

        if (_rawDepth == null)
        {
            return new CommandBuildResult.Failure(
                new BuildingError("You must call WithDepth first"));
        }

        int depth;
        if (!int.TryParse(_rawDepth, out depth))
        {
            return new CommandBuildResult.Failure(new BuildingError("Wrong depth"));
        }

        return new CommandBuildResult.Success(new TreeListCommand(_drawer, depth));
    }
}