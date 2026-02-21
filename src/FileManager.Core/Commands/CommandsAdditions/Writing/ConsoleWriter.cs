namespace FileManager.Core.Commands.CommandsAdditions.Writing;

public class ConsoleWriter : IWriter
{
    public void Write(string text)
    {
        Console.WriteLine(text);
    }
}