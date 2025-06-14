namespace NCalculator.Core.Models;

/// <summary>
/// Data for command of user input
/// </summary>
/// <param name="command">Command from user</param>
/// <param name="args">Arguments for command</param>
/// <param name="options">Options for command</param>
/// <remarks>Options are optional and must be declared via "-"</remarks>
public record CommandData(string command, string[] args, CommandOptions options);