using AddressBookApp.Services;

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
}