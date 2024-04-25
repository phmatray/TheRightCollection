using System.Collections;

namespace TheRightCollection.ConsoleApp.People;

/// <summary>
/// Represents a collection of people.
/// </summary>
public class PersonCollection
    : IEnumerable<Person>
{
    private readonly List<Person> _people = [];
    
    // Event declaration.
    public event EventHandler<PersonEventArgs>? PersonAdded;
    public event EventHandler<PersonEventArgs>? PersonRemoved;
    
    // Indexer declaration.
    public Person this[int index]
    {
        get => _people[index];
        set => _people[index] = value;
    }
    
    // Indexer declaration with a string key.
    public Person this[string name]
        => _people.First(p => p.Name == name);
    
    public void Add(Person person)
    {
        _people.Add(person);
        OnPersonAdded(person);
    }

    public bool Remove(Person person)
    {
        var wasRemoved = _people.Remove(person);
        if (wasRemoved)
        {
            OnPersonRemoved(person);
        }
        return wasRemoved;
    }

    public int Count
        => _people.Count;
    
    public IEnumerable<Person> FindByName(string name)
        => _people.Where(p => p.Name == name);
    
    public void SortByName()
        => _people.Sort((x, y) => x.Name.CompareTo(y.Name));
    
    public void SortByAge()
        => _people.Sort((x, y) => x.Age.CompareTo(y.Age));
    
    public IEnumerable<Person> FilterByAge(int minimumAge)
        => _people.Where(p => p.Age >= minimumAge);
    
    public double AverageAge()
        => _people.Average(p => p.Age);
    
    public Person OldestPerson()
        => _people.OrderByDescending(p => p.Age).First();
    
    public Person YoungestPerson()
        => _people.OrderBy(p => p.Age).First();
    
    // Event invocation methods.
    protected virtual void OnPersonAdded(Person person)
        => PersonAdded?.Invoke(this, new PersonEventArgs(person));
    
    protected virtual void OnPersonRemoved(Person person)
        => PersonRemoved?.Invoke(this, new PersonEventArgs(person));

    // IEnumerable implementation.
    public IEnumerator<Person> GetEnumerator()
        => _people.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();
}