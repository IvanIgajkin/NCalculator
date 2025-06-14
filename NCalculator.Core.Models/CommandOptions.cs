namespace NCalculator.Core.Models;

[Flags]
public enum CommandOptions
{
	/// <summary>
	/// Show help info about command
	/// </summary>
	HelpOption = 1,
	/// <summary>
	/// Use user arguments as integer values
	/// </summary>
	UseIntegerValues = 2,
	/// <summary>
	/// Show expression from user input with result
	/// </summary>
	ExpressionOutput = 4,
}