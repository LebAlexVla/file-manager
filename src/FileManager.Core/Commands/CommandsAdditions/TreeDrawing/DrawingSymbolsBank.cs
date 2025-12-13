namespace FileManager.Core.Commands.CommandsAdditions.TreeDrawing;

public class DrawingSymbolsBank
{
    public DrawingSymbolsBank(string fileSymbol, string directorySymbol, string indentSymbol)
    {
        FileSymbol = fileSymbol;
        DirectorySymbol = directorySymbol;
        IndentSymbol = indentSymbol;
    }

    public string FileSymbol { get; }

    public string DirectorySymbol { get; }

    public string IndentSymbol { get; }
}