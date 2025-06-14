using NCalculator.Core.Models;

namespace NCalculator.ConsoleShell.Utils;

/// <summary>
/// Extension methods for <see cref="Console"/>
/// </summary>
public static class ConsoleShell
{
	private const string WelcomeText = @"Welcome to NCalculator!
Please, enter command to start calculation or get help.
Use ""quit"" to close application.";

	/// <summary>
	/// Print welcome text in console
	/// </summary>
	public static void Welcome()
	{
		Console.WriteLine(WelcomeText);
	}

	/// <summary>
	/// Read command data from user input
	/// </summary>
	/// <returns>Command data from user input (<see cref="CommandData"/></returns>
	/// <exception cref="ArgumentException">Empty user input</exception>
	public static CommandData ReadCommand()
	{
		Console.Write("> ");
		var userInput = Console.ReadLine()?.Split(' ');
		if (userInput?.Length is null or < 1)
		{
			throw new ArgumentException("Empty command");
		}

		var command = userInput[0];
		var args = userInput.Skip(1).Where(arg => !string.IsNullOrWhiteSpace(arg)).ToArray();
		
		return new CommandData(command, args);
	}
}