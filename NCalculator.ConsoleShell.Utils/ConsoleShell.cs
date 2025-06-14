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
		var argsLookup = userInput
			.Skip(1)
			.Where(arg => !string.IsNullOrWhiteSpace(arg))
			.ToLookup(arg => arg.StartsWith("--"));
		
		var args = argsLookup[false].ToArray();

		var optionKeys = argsLookup[true].ToArray();
		if (!CommandOptionsParser.TryParse(optionKeys, out var options))
		{
			if (optionKeys.Length > 0)
			{
				throw new ArgumentException("Invalid options for user command");
			}
		}
		
		return new CommandData(command, args, options);
	}

	/// <summary>
	/// Write application error in error stream 
	/// </summary>
	/// <param name="message">Message from error/exception</param>
	public static void Error(string message)
	{
		Console.Error.WriteLine($"Error: {message}");
	}

	/// <summary>
	/// Exit from application and close it
	/// </summary>
	public static void Exit()
	{
		Environment.Exit(0);
	}
}