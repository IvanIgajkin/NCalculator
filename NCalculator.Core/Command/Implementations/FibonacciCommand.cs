using NCalculator.Core.Models;

namespace NCalculator.Core.Command.Implementations;

/// <summary>
/// Calculate fibonacci number
/// </summary>
internal class FibonacciCommand : ICommand, ICommandHelp
{
	private readonly CommandOptions _options;
	private readonly int _orderNumber;

	internal FibonacciCommand(string[] args, CommandOptions? options)
	{
		_options = options ?? new CommandOptions();

		if (!_options.HasFlag(CommandOptions.HelpOption))
		{
			if (args.Length < 1)
			{
				throw new ArgumentException("Invalid number of arguments. Enter fibonacci order number.");
			}

			if (!int.TryParse(args[0], out _orderNumber))
			{
				throw new ArgumentException("Argument is not integer value. Enter fibonacci order number.");
			}
		}
	}
	
	public void Execute()
	{
		if (_options.HasFlag(CommandOptions.HelpOption))
		{
			GetHelp();
			return;
		}
		
		var fibonacciNumber = Fibonacci(_orderNumber);
		Console.WriteLine($"Fibonacci with number {_orderNumber} is {fibonacciNumber}");
	}

	/// <summary>
	/// Perform fibonacci number (recursive)
	/// </summary>
	/// <param name="n">Fibonacci order number</param>
	/// <returns></returns>
	private static long Fibonacci(long n)
	{
		return n > 2 ? Fibonacci(n - 1) + Fibonacci(n - 2) : 1;
	}

	public void GetHelp()
	{
		Console.WriteLine(@"fib <options> <order number>
	Available options:
		--h: show this help about fib command (fib --h)
	Description: calculate a fibonacci number by its order number in sequences;
	Example: fib 6
	Answer: Fibonacci with number 6 is 8");
	}
}