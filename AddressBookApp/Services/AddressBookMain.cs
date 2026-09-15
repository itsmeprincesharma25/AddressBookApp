using AddressBookApp.Services;
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
}