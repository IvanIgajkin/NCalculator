using NCalculator.Core.Models;

namespace NCalculator.Core.Command.Implementations;

public class CalculationCommand : BaseCommandWithOptions, ICommand
{
	private readonly string _operation;
	private readonly string[] _args;

	protected override string HelpText => @"calc <option> <operation> <args>"; 
	
	public CalculationCommand(String[] args, CommandOptions options) : base(options)
	{
		if (!Options.HasFlag(CommandOptions.HelpOption))
		{
			if (args.Length < 3)
			{
				throw new ArgumentException($"Please provide three arguments: operation symbol and two numeric arguments.");
			}
		
			_operation = args[0].Trim();
			_args = args.Skip(1).ToArray();	
		}
	}
	
	public void Execute()
	{
		if (Options.HasFlag(CommandOptions.HelpOption))
		{
			GetHelp();
			return;
		}
		
		dynamic args = Options.HasFlag(CommandOptions.UseIntegerValues)
			? _args.Select(long.Parse).ToArray()
			: _args.Select(decimal.Parse).ToArray();

		var result = _operation switch
		{
			"+" => args[0] + args[1],
			"-" => args[0] - args[1],
			"*" => args[0] * args[1],
			"/" => args[0] / args[1],
			"^" => Math.Pow(args[0], args[1]),
			_ => throw new ArgumentException($"Unknown operation: {_operation}"),
		};

		Console.WriteLine(Options.HasFlag(CommandOptions.ExpressionOutput)
			? $"{_args[0]} {_operation} {_args[1]} = {result}"
			: $"Result: {result}");
	}
}