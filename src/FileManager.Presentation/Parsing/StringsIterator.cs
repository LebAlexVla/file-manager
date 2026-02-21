namespace FileManager.Presentation.Parsing;

public class StringsIterator
{
    private readonly string[] _strings;

    private int _index;

    public StringsIterator(string[] tokens)
    {
        _strings = tokens;
        _index = 0;
    }

    public string Current => _strings[_index];

    public bool IsLast => _index == _strings.Length - 1;

    public string MoveNext()
    {
        _index++;

        return _strings[_index];
    }
}