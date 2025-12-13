namespace FileManager.Core.Commands.CommandsAdditions.TreeDrawing;

public class StandardDrawingSymbolsBankFactory : IDrawingSymbolsBankFactory
{
    private const string FileSymbol = "*";

    private const string DirectorySymbol = "#";

    private const string IndentSymbol = "_";

    public DrawingSymbolsBank Create()
    {
        return new DrawingSymbolsBank(FileSymbol, DirectorySymbol, IndentSymbol);
    }
}