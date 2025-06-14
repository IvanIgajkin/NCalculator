using NCalculator.Core.Command.Implementations;
using NCalculator.Core.Models;

namespace NCalculator.Core.Command;

/// <summary>
/// Wrapper for factory method to create implementations of <see cref="ICommand"/>
/// </summary>
public static class CommandFactory
{
	/// <summary>
	/// Create implementations of <see cref="ICommand"/> by user input
	/// </summary>
	/// <param name="data">Data of user input (<see cref="CommandData"/>)</param>
	/// <returns>Implementation of <see cref="ICommand"/> in correlation with user input</returns>
	/// <exception cref="ArgumentException">Unknown command from user</exception>
	public static ICommand Create(CommandData data)
	{
		return data.command.Trim() switch
		{
			"gcd" => new GcdCommand(data.args),
			"fib" => new FibonacciCommand(data.args),
			"help" => new HelpCommand(),
			"quit" => new QuitCommand(),
			_ => throw new ArgumentException("Unknown command")
		};
	}
}