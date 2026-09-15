using AddressBookApp.Models;

namespace AddressBookApp.Services;

public class AddressBookMain
{
    private readonly List<AddressBook> books = new();

    public void AddAddressBook(AddressBook addressBook)
    {
        books.Add(addressBook);
    }

    public int GetTotalContactCount()
    {
        return books.Sum(book => book.Contacts.Count);
    }
    public IReadOnlyList<Contact> SearchByCity(string city)
    {
        return books
            .SelectMany(book => book.Contacts)
            .Where(contact =>
                contact.City.Equals(city, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public IReadOnlyList<Contact> SearchByState(string state)
    {
        return books
            .SelectMany(book => book.Contacts)
            .Where(contact =>
                contact.State.Equals(state, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
    
    public void ViewByCityOrState()
    {
        List<Contact> contacts = books
            .SelectMany(book => book.Contacts)
            .ToList();

        Console.WriteLine("\n--- By City ---");

        foreach (IGrouping<string, Contact> group in contacts.GroupBy(contact => contact.City))
        {
            Console.WriteLine($"{group.Key}:");

            foreach (Contact contact in group)
            {
                Console.WriteLine($" {contact.FirstName} {contact.LastName}");
            }
        }

        Console.WriteLine("\n--- By State ---");

        foreach (IGrouping<string, Contact> group in contacts.GroupBy(contact => contact.State))
        {
            Console.WriteLine($"{group.Key}:");

            foreach (Contact contact in group)
            {
                Console.WriteLine($" {contact.FirstName} {contact.LastName}");
            }
        }
    }
}