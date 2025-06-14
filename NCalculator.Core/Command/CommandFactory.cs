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
			"calc" => new CalculationCommand(data.args, data.options),
			"gcd" => new GcdCommand(data.args, data.options),
			"fib" => new FibonacciCommand(data.args, data.options),
			"help" => new HelpCommand(),
			"quit" => new QuitCommand(),
			null or "" => throw new NullReferenceException("Empty input while reading command"),
			_ => throw new ArgumentException("Unknown command")
		};
	}
}