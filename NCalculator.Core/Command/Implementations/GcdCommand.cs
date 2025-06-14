using NCalculator.Core.Models;

namespace NCalculator.Core.Command.Implementations;

/// <summary>
/// Calculate GCD of two numbers
/// </summary>
internal class GcdCommand : ICommand, ICommandHelp
{
	private readonly long[] _args;
	private readonly CommandOptions _options;

	internal GcdCommand(string[] args, CommandOptions? options)
	{
		_options = options ?? new CommandOptions();
		
		if (args.Length < 2 && !_options.HasFlag(CommandOptions.HelpOption))
		{
			throw new ArgumentException("Invalid number of arguments. GCD needs at least two arguments.");
		}
		
		_args = args.Select(x => Convert.ToInt64(x)).ToArray();
	}
	
	public void Execute()
	{
		if (_options.HasFlag(CommandOptions.HelpOption))
		{
			GetHelp();
			return;
		}
		
		var gcd = Gcd(_args[0], _args[1]);
		Console.WriteLine($"GCD of {_args[0]} and {_args[1]} is {gcd}");
	}

	/// <summary>
	/// Perform GCD of two numbers (recursive)
	/// </summary>
	/// <param name="a">First argument</param>
	/// <param name="b">Second argument</param>
	/// <returns></returns>
	private static long Gcd(long a, long b)
	{
		return b == 0 ? a : Gcd(b, a % b);
	}
	
	public void GetHelp()
	{
		Console.WriteLine(@"gcd <options> <first number> <second number>
	Available options:
		--h: show this help about gcd command (gcd --h)
	Description: calculate a greatest common delimiter ow a two numbers;
	Example: gcd 36 48
	Answer: GCD of 36 and 48 is 12");
	}
}