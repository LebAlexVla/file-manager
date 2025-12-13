namespace FileManager.Core.Commands.CommandsAdditions.TreeDrawing;

public class ConsoleDrawer : IDrawer
{
    private readonly DrawingSymbolsBank _drawingSymbolsBank;

    public ConsoleDrawer(DrawingSymbolsBank bank)
    {
        _drawingSymbolsBank = bank;
    }

    public void DrawDirectory(string directory)
    {
        Console.WriteLine(_drawingSymbolsBank.DirectorySymbol + directory);
    }

    public void DrawFile(string filename)
    {
        Console.WriteLine(_drawingSymbolsBank.FileSymbol + filename);
    }

    public void DrawIndent()
    {
        Console.WriteLine(_drawingSymbolsBank.IndentSymbol);
    }
}