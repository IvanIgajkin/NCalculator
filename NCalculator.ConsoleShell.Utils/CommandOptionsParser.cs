using NCalculator.Core.Models;

namespace NCalculator.ConsoleShell.Utils;

/// <summary>
/// Parser for <see cref="CommandOptions"/>
/// </summary>
public static class CommandOptionsParser
{
	/// <summary>
	/// Parse active options from user input
	/// </summary>
	/// <param name="optionsKeys">Options keys from iser input</param>
	/// <returns>Available options for command (<see cref="CommandOptions"/>)</returns>
	public static CommandOptions Parse(string optionsKeys)
	{
		var keys = optionsKeys.Skip(1).ToArray();
		
		var options = new CommandOptions();
		
		if (keys.Contains('i'))
		{
			options |= CommandOptions.UseIntegerValues;
		}
		
		if (keys.Contains('v'))
		{
			options |= CommandOptions.ExpressionOutput;
		}
		
		if (keys.Contains('h'))
		{
			if (options is not new CommandOptions())
			{
				throw new ApplicationException("Can't use option -h with another options");
			}
			
			options |= CommandOptions.HelpOption;
		}
		
		return options;
	}
}