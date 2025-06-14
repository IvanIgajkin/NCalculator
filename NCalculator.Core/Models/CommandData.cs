namespace NCalculator.Core.Models;

/// <summary>
/// Data for command of user input
/// </summary>
/// <param name="command">Command from user</param>
/// <param name="args">Arguments for command</param>
public record CommandData(string command, string[] args);