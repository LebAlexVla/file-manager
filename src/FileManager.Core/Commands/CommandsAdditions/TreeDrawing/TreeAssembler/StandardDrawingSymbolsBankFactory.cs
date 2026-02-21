namespace FileManager.Core.Commands.CommandsAdditions.TreeDrawing.TreeAssembler;

public class StandardDrawingSymbolsBankFactory : IDrawingSymbolsBankFactory
{
    private const char FileSymbol = '*';

    private const char DirectorySymbol = '#';

    private const char IndentSymbol = '_';

    public DrawingSymbolsBank Create()
    {
        return new DrawingSymbolsBank(FileSymbol, DirectorySymbol, IndentSymbol);
    }
}