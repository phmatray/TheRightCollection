namespace TheRightCollection.ConsoleApp.People;

/// <summary>
/// Represents a person.
/// </summary>
/// <param name="Name">The name of the person.</param>
/// <param name="Age">The age of the person.</param>
public record Person(string Name, int Age)
{
    /// <inheritdoc/>
    public override string ToString()
        => $"{Name}, {Age} years old";
}