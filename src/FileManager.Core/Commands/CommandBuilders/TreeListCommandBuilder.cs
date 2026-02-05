using FileManager.Core.Commands.CommandsAdditions.TreeDrawing;
using FileManager.Core.Errors;

namespace FileManager.Core.Commands.CommandBuilders;

public class TreeListCommandBuilder : ICommandBuilder
{
    private IDrawer? _drawer;
    private int _depth;

    public TreeListCommandBuilder WithDrawer(IDrawer drawer)
    {
        _drawer = drawer;

        return this;
    }

    public TreeListCommandBuilder WithDepth(int depth)
    {
        _depth = depth;

        return this;
    }

    public CommandBuildResult Build()
    {
        if (_drawer == null)
        {
            return new CommandBuildResult.Failure(
                new BuildingError("You must call WithDrawer or WithDepth first"));
        }

        return new CommandBuildResult.Success(new TreeListCommand(_drawer, _depth));
    }
}