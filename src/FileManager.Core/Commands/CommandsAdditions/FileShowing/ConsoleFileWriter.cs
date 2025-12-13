namespace FileManager.Core.Commands.CommandsAdditions.FileShowing;

public class ConsoleFileWriter : IFileWriter
{
    public void Write(string content)
    {
        Console.WriteLine(content);
    }
}