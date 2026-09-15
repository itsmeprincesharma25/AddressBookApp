using AddressBookApp.Exceptions;
using AddressBookApp.Models;
using AddressBookApp.Services;
using AddressBookApp.Validation;

AddressBook addressBook = new();
AddressBookMain addressBookMain = new();

addressBookMain.AddAddressBook(addressBook);

while (true)
{
    ShowMenu();

    string choice = Console.ReadLine() ?? "";

    switch (choice)
    {
        case "1":
            AddContact(addressBook);
            break;

        case "2":
            addressBook.PrintAll();
            break;

        case "3":
            EditContact(addressBook);
            break;

        case "4":
            DeleteContact(addressBook);
            break;

        case "5":
            Console.WriteLine(
                $"Total contacts in all address books: {addressBookMain.GetTotalContactCount()}");
            break;

        case "6":
            SearchByCity(addressBookMain);
            break;

        case "7":
            SearchByState(addressBookMain);
            break;

        case "8":
            addressBookMain.ViewByCityOrState();
            break;

        case "9":
            addressBookMain.GetCountByCityOrState();
            break;

        case "10":
            PrintContacts(addressBook.SortByName());
            break;

        case "11":
            PrintContacts(addressBook.SortByCity());
            break;

        case "12":
            PrintContacts(addressBook.SortByState());
            break;

        case "13":
            PrintContacts(addressBook.SortByZip());
            break;

        case "0":
            return;

        default:
            Console.WriteLine("Invalid choice.");
            break;
    }
}

static void ShowMenu()
{
    Console.WriteLine("\n1. Add Contact");
    Console.WriteLine("2. Show All Contacts");
    Console.WriteLine("3. Edit Contact");
    Console.WriteLine("4. Delete Contact");
    Console.WriteLine("5. Total Contact Count");
    Console.WriteLine("6. Search by City");
    Console.WriteLine("7. Search by State");
    Console.WriteLine("8. View Contacts by City/State");
    Console.WriteLine("9. Count Contacts by City/State");
    Console.WriteLine("10. Sort Contacts by Name");
    Console.WriteLine("11. Sort Contacts by City");
    Console.WriteLine("12. Sort Contacts by State");
    Console.WriteLine("13. Sort Contacts by Zip");
    Console.WriteLine("0. Exit");
    Console.Write("Enter your choice: ");
}

static void AddContact(AddressBook addressBook)
{
    Contact contact = ReadContact();

    try
    {
        ContactValidator.Validate(contact);
        addressBook.AddContact(contact);
        Console.WriteLine("Contact added successfully.");
    }
    catch (InvalidContactException ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}

static Contact ReadContact()
{
    Console.Write("Enter first name: ");
    string firstName = Console.ReadLine() ?? "";

    Console.Write("Enter last name: ");
    string lastName = Console.ReadLine() ?? "";

    Console.Write("Enter address: ");
    string address = Console.ReadLine() ?? "";

    Console.Write("Enter city: ");
    string city = Console.ReadLine() ?? "";

    Console.Write("Enter state: ");
    string state = Console.ReadLine() ?? "";

    Console.Write("Enter zip: ");
    string zip = Console.ReadLine() ?? "";

    Console.Write("Enter phone number: ");
    string phoneNumber = Console.ReadLine() ?? "";

    Console.Write("Enter email: ");
    string email = Console.ReadLine() ?? "";

    return new Contact(
        firstName,
        lastName,
        address,
        city,
        state,
        zip,
        phoneNumber,
        email
    );
}

static void EditContact(AddressBook addressBook)
{
    Console.Write("Enter first name to edit: ");
    string firstName = Console.ReadLine() ?? "";

    Console.Write("Enter last name to edit: ");
    string lastName = Console.ReadLine() ?? "";

    addressBook.EditContact(firstName, lastName);
}

static void DeleteContact(AddressBook addressBook)
{
    Console.Write("Enter first name to delete: ");
    string firstName = Console.ReadLine() ?? "";

    Console.Write("Enter last name to delete: ");
    string lastName = Console.ReadLine() ?? "";

    addressBook.DeleteContact(firstName, lastName);
}

static void SearchByCity(AddressBookMain addressBookMain)
{
    Console.Write("Enter city to search: ");
    string city = Console.ReadLine() ?? "";

    IReadOnlyList<Contact> results = addressBookMain.SearchByCity(city);

    PrintSearchResults(results);
}

static void SearchByState(AddressBookMain addressBookMain)
{
    Console.Write("Enter state to search: ");
    string state = Console.ReadLine() ?? "";

    IReadOnlyList<Contact> results = addressBookMain.SearchByState(state);

    PrintSearchResults(results);
}

static void PrintSearchResults(IReadOnlyList<Contact> contacts)
{
    Console.WriteLine($"Found {contacts.Count} contact(s):");

    foreach (Contact contact in contacts)
    {
        Console.WriteLine(contact);
    }
}

static void PrintContacts(IReadOnlyList<Contact> contacts)
{
    foreach (Contact contact in contacts)
    {
        Console.WriteLine(contact);
    }
}