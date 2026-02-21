using System.Text;

namespace FileManager.Core.Commands.CommandsAdditions.TreeDrawing.TreeAssembler;

public class StandardTreeDrawAssembler : ITreeDrawAssembler
{
    private readonly StringBuilder _stringBuilder;
    private readonly DrawingSymbolsBank _symbolsBank;

    public StandardTreeDrawAssembler(DrawingSymbolsBank symbolsBank)
    {
        _stringBuilder = new StringBuilder();
        _symbolsBank = symbolsBank;
    }

    public void AssembleFile(string fileName, int depth)
    {
        _stringBuilder.Append(_symbolsBank.IndentSymbol, depth);
        _stringBuilder.Append(_symbolsBank.FileSymbol);
        _stringBuilder.AppendLine(fileName);
    }

    public void AssembleDirectory(string directoryName, int depth)
    {
        _stringBuilder.Append(_symbolsBank.IndentSymbol, depth);
        _stringBuilder.Append(_symbolsBank.DirectorySymbol);
        _stringBuilder.AppendLine(directoryName);
    }

    public string GetResult()
    {
        return _stringBuilder.ToString();
    }
}