using System.Collections;

namespace TheRightCollection.ConsoleApp.People;

/// <summary>
/// Represents a collection of people, providing methods for sorting, filtering,
/// and managing events when people are added or removed.
/// </summary>
public class PersonCollection
    : IEnumerable<Person>
{
    private readonly List<Person> _people = [];
    
    /// <summary>
    /// Occurs when a person is added to the collection.
    /// </summary>
    public event EventHandler<PersonEventArgs>? PersonAdded;
    
    /// <summary>
    /// Occurs when a person is removed from the collection.
    /// </summary>
    public event EventHandler<PersonEventArgs>? PersonRemoved;
    
    /// <summary>
    /// Gets or sets the person at the specified index.
    /// </summary>
    /// <param name="index">The zero-based index of the person to get or set.</param>
    /// <returns>The person at the specified index.</returns>
    public Person this[int index]
    {
        get => _people[index];
        set => _people[index] = value;
    }
    
    /// <summary>
    /// Gets the person with the specified name. Assumes name is unique.
    /// </summary>
    /// <param name="name">The name of the person to find.</param>
    /// <returns>The person with the specified name.</returns>
    public Person this[string name]
        => _people.First(p => p.Name == name);
    
    /// <summary>
    /// Adds a person to the collection and raises the PersonAdded event.
    /// </summary>
    /// <param name="person">The person to add.</param>
    public void Add(Person person)
    {
        _people.Add(person);
        OnPersonAdded(person);
    }

    /// <summary>
    /// Removes a person from the collection and raises the PersonRemoved event if the person was successfully removed.
    /// </summary>
    /// <param name="person">The person to remove.</param>
    /// <returns>true if the person was successfully removed; otherwise, false.</returns>
    public bool Remove(Person person)
    {
        var wasRemoved = _people.Remove(person);
        if (wasRemoved)
        {
            OnPersonRemoved(person);
        }
        return wasRemoved;
    }

    /// <summary>
    /// Gets the number of people contained in the collection.
    /// </summary>
    public int Count
        => _people.Count;
    
    /// <summary>
    /// Finds all people with the specified name.
    /// </summary>
    /// <param name="name">The name to search for.</param>
    /// <returns>An enumerable of people with the specified name.</returns>
    public IEnumerable<Person> FindByName(string name)
        => _people.Where(p => p.Name == name);
    
    /// <summary>
    /// Sorts the collection of people by name.
    /// </summary>
    public void SortByName()
        => _people.Sort((x, y) => x.Name.CompareTo(y.Name));
    
    /// <summary>
    /// Sorts the collection of people by age.
    /// </summary>
    public void SortByAge()
        => _people.Sort((x, y) => x.Age.CompareTo(y.Age));
    
    /// <summary>
    /// Filters the collection to get people who are at least the specified age.
    /// </summary>
    /// <param name="minimumAge">The minimum age to filter by.</param>
    /// <returns>An enumerable of people who are at least the specified age.</returns>
    public IEnumerable<Person> FilterByAge(int minimumAge)
        => _people.Where(p => p.Age >= minimumAge);
    
    /// <summary>
    /// Calculates the average age of all people in the collection.
    /// </summary>
    /// <returns>The average age of people.</returns>
    public double AverageAge()
        => _people.Average(p => p.Age);
    
    /// <summary>
    /// Returns the oldest person in the collection.
    /// </summary>
    /// <returns>The oldest person.</returns>
    public Person OldestPerson()
        => _people.OrderByDescending(p => p.Age).First();
    
    /// <summary>
    /// Returns the youngest person in the collection.
    /// </summary>
    /// <returns>The youngest person.</returns>
    public Person YoungestPerson()
        => _people.OrderBy(p => p.Age).First();
    
    /// <summary>
    /// Protected method to raise the PersonAdded event.
    /// </summary>
    /// <param name="person">The person added to the collection.</param>
    protected virtual void OnPersonAdded(Person person)
        => PersonAdded?.Invoke(this, new PersonEventArgs(person));
    
    /// <summary>
    /// Protected method to raise the PersonRemoved event.
    /// </summary>
    /// <param name="person">The person removed from the collection.</param>
    protected virtual void OnPersonRemoved(Person person)
        => PersonRemoved?.Invoke(this, new PersonEventArgs(person));

    /// <inheritdoc />
    public IEnumerator<Person> GetEnumerator()
        => _people.GetEnumerator();

    /// <inheritdoc />
    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();
}