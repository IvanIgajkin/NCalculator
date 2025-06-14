namespace NCalculator.Core.Command.Implementations;

/// <summary>
/// Command to show help for user
/// </summary>
internal class HelpCommand : ICommand
{
	private const string HelpText = @"List of available commands:
	* gcd - get GCD of two numbers,
		Example: gcd 36 48
		Answer: GCD of 36 and 48 is 12;
	* fib - get value of fibonacci number sequences,
		Example: fib 6
		Answer: Fibonacci with number 6 is 8;
	* help - use this command to show this text;
	* quit - close application.";
    
	public void Execute()
	{
        Console.WriteLine(HelpText);
	}
}