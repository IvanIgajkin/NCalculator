using NCalculator.Core.Models;

namespace NCalculator.ConsoleShell.Utils;

/// <summary>
/// Parser for <see cref="CommandOptions"/>
/// </summary>
public static class CommandOptionsParser
{
	/// <summary>
	/// Try parse active options from user input
	/// </summary>
	/// <param name="optionsKeys">Options keys from iser input</param>
	/// <param name="options"></param>
	/// <returns>True, if value was parsed, or false, if available options were not found</returns>
	public static bool TryParse(string[] optionsKeys, out CommandOptions? options)
	{
		options = null;
		
		if (optionsKeys.Contains("--h"))
		{
			options = CommandOptions.HelpOption;
		}
		
		return options is not null;
	}
}