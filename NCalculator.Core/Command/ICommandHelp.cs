namespace NCalculator.Core.Command;

/// <summary>
/// Command that support help option
/// </summary>
internal interface ICommandHelp
{
	/// <summary>
	/// Show help info about user command
	/// </summary>
	void GetHelp();
}