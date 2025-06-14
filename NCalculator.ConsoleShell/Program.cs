using NCalculator.ConsoleShell.Utils;
using NCalculator.Core.Command;

ConsoleShell.Welcome();

while (true)
{
	try
	{
		var userCommandData = ConsoleShell.ReadCommand();
		
		var command = CommandFactory.Create(userCommandData);
		command.Execute();
	}
	catch (Exception e)
	{
		Console.WriteLine($"Error: {e.Message}");
	}
}