namespace TheRightCollection.ConsoleApp.People;

/// <summary>
/// Represents the event arguments for a person.
/// </summary>
/// <param name="person">The person.</param>
public class PersonEventArgs(Person person)
    : EventArgs
{
    public Person Person { get; } = person;
}