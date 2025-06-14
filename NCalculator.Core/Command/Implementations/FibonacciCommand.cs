namespace NCalculator.Core.Command.Implementations;

/// <summary>
/// Calculate fibonacci number
/// </summary>
internal class FibonacciCommand : ICommand
{
	private readonly int _orderNumber;

	internal FibonacciCommand(string[] args)
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
	
	public void Execute()
	{
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
}