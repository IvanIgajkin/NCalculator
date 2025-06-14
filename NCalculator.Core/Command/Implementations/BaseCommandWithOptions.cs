using NCalculator.Core.Models;

namespace NCalculator.Core.Command.Implementations;

/// <summary>
/// Base class for command that support options
/// </summary>
public abstract class BaseCommandWithOptions
{
	/// <summary>
	/// Option from user input
	/// </summary>
	protected readonly CommandOptions Options;
	/// <summary>
	/// Help info for the command
	/// </summary>
	protected abstract string HelpText { get; }

	protected BaseCommandWithOptions(CommandOptions? options)
	{
		Options = options ?? new CommandOptions();
	}

	/// <summary>
	/// Get help info about the command
	/// </summary>
	protected void GetHelp()
	{
		Console.WriteLine(HelpText);
	}
}