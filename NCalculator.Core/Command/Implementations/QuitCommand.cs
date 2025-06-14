using Shell = NCalculator.ConsoleShell.Utils.ConsoleShell;

namespace NCalculator.Core.Command.Implementations;

/// <summary>
/// User command to quit from application
/// </summary>
internal class QuitCommand : ICommand
{
	public void Execute()
	{
		Shell.Exit();
	}
}