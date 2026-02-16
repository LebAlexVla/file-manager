using FileManager.Core.CommandsExecuting;

namespace FileManager.Core.Commands;

public interface ICommand
{
    CommandResult Execute(IContext context);
}