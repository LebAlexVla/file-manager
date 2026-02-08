namespace FileManager.Core.Commands.CommandsAdditions.TreeDrawing.TreeAssembler;

public class DrawingSymbolsBank
{
    public DrawingSymbolsBank(char fileSymbol, char directorySymbol, char indentSymbol)
    {
        FileSymbol = fileSymbol;
        DirectorySymbol = directorySymbol;
        IndentSymbol = indentSymbol;
    }

    public char FileSymbol { get; }

    public char DirectorySymbol { get; }

    public char IndentSymbol { get; }
}