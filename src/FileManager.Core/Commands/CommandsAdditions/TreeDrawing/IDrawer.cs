namespace FileManager.Core.Commands.CommandsAdditions.TreeDrawing;

public interface IDrawer
{
    void DrawDirectory(string directory);

    void DrawFile(string filename);

    void DrawIndent();
}