using FileManager.Core.Commands.CommandsAdditions.TreeDrawing;

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

    public ICommand Build()
    {
        if (_drawer == null)
        {
            throw new InvalidOperationException("You must call WithDrawer or WithDepth first");
        }

        return new TreeListCommand(_drawer, _depth);
    }
}