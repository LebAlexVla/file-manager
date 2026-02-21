namespace FileManager.Core.Commands.CommandsAdditions.TreeDrawing.TreeAssembler;

public interface ITreeDrawAssembler
{
    void AssembleFile(string fileName, int depth);

    void AssembleDirectory(string directoryName, int depth);

    string GetResult();
}