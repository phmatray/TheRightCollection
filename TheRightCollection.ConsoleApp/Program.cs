using TheRightCollection.ConsoleApp.People;
using static System.Console;

WriteLine("The Right Collection");
WriteLine("---------------------");
WriteLine("This project demonstrates how to encapsulate a collection of items in a class that provides a more meaningful interface than the built-in collection types.");

WriteLine();
WriteLine("Create a collection of people:");
PersonCollection people =
[
    new Person("Alice", 40),
    new Person("Bob", 35),
    new Person("Charlie", 50)
];

WriteLine();
WriteLine("People:");
WriteCollection(people);

WriteLine();
WriteLine("People named 'Bob':");
WriteCollection(people.FindByName("Bob"));

WriteLine();
WriteLine("Sort by age:");
people.SortByAge();
WriteCollection(people);

WriteLine();
WriteLine("Get the oldest person:");
WriteLine(people.OldestPerson());

// Event handlers.
WriteLine();
WriteLine("Subscribe to events:");
people.PersonAdded += (sender, e) => WriteLine($"Person added: {e.Person}");
people.PersonRemoved += (sender, e) => WriteLine($"Person removed: {e.Person}");
// remove Bob
var bob = people["Bob"];
people.Remove(bob);
// add Bob back
people.Add(bob);
WriteCollection(people);

return;

void WriteCollection<T>(IEnumerable<T> collection)
{
    foreach (var item in collection)
    {
        WriteLine($"- {item}");
    }
}
