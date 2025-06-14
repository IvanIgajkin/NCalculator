namespace NCalculator.Core.Command.Implementations;

/// <summary>
/// Calculate GCD of two numbers
/// </summary>
internal class GcdCommand : ICommand
{
	private readonly long[] _args;

	internal GcdCommand(string[] args)
	{
		if (args.Length < 2)
		{
			throw new ArgumentException("Invalid number of arguments. GCD needs at least two arguments.");
		}
		
		_args = args.Select(x => Convert.ToInt64(x)).ToArray();
	}
	
	public void Execute()
	{
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
}