using AddressBookApp.Exceptions;
using AddressBookApp.Models;
using AddressBookApp.Validation;

namespace AddressBookApp.Services;

public class AddressBook
{
    private readonly List<Contact> contacts = new();

    public IReadOnlyList<Contact> Contacts => contacts;

    public void AddContact(Contact contact)
    {
        bool exists = contacts.Any(
            c => c.FirstName == contact.FirstName &&
                 c.LastName == contact.LastName);

        if (exists)
        {
            Console.WriteLine(
                $"Contact '{contact.FirstName} {contact.LastName}' already exists. Duplicate not added.");
            return;
        }

        contacts.Add(contact);
    }

    public void PrintAll()
    {
        foreach (Contact contact in contacts)
        {
            Console.WriteLine(contact);
        }
    }

    public void EditContact(string firstName, string lastName)
    {
        Contact? contact = contacts.FirstOrDefault(
            c => c.FirstName == firstName && c.LastName == lastName);

        if (contact == null)
        {
            Console.WriteLine("Contact not found.");
            return;
        }

        Console.WriteLine($"Editing: {contact}");

        string newFirstName = ReadValue(
            "Enter new first name (or press Enter to keep): ",
            contact.FirstName);

        string newLastName = ReadValue(
            "Enter new last name (or press Enter to keep): ",
            contact.LastName);

        string newAddress = ReadValue(
            "Enter new address (or press Enter to keep): ",
            contact.Address);

        string newCity = ReadValue(
            "Enter new city (or press Enter to keep): ",
            contact.City);

        string newState = ReadValue(
            "Enter new state (or press Enter to keep): ",
            contact.State);

        string newZip = ReadValue(
            "Enter new zip (or press Enter to keep): ",
            contact.Zip);

        string newPhoneNumber = ReadValue(
            "Enter new phone number (or press Enter to keep): ",
            contact.PhoneNumber);

        string newEmail = ReadValue(
            "Enter new email (or press Enter to keep): ",
            contact.Email);

        Contact updatedContact = new(
            newFirstName,
            newLastName,
            newAddress,
            newCity,
            newState,
            newZip,
            newPhoneNumber,
            newEmail
        );

        try
        {
            ContactValidator.Validate(updatedContact);

            contact.FirstName = updatedContact.FirstName;
            contact.LastName = updatedContact.LastName;
            contact.Address = updatedContact.Address;
            contact.City = updatedContact.City;
            contact.State = updatedContact.State;
            contact.Zip = updatedContact.Zip;
            contact.PhoneNumber = updatedContact.PhoneNumber;
            contact.Email = updatedContact.Email;

            Console.WriteLine("Contact updated.");
        }
        catch (InvalidContactException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    
    public void DeleteContact(string firstName, string lastName)
    {
        Contact? contact = contacts.FirstOrDefault(
            c => c.FirstName == firstName && c.LastName == lastName);

        if (contact == null)
        {
            Console.WriteLine("Contact not found.");
            return;
        }

        contacts.Remove(contact);
        Console.WriteLine("Contact deleted.");
    }
    public IReadOnlyList<Contact> SortByName()
    {
        return contacts
            .OrderBy(contact => contact.FirstName)
            .ThenBy(contact => contact.LastName)
            .ToList();
    }
    public IReadOnlyList<Contact> SortByCity()
    {
        return contacts
            .OrderBy(contact => contact.City)
            .ToList();
    }

    public IReadOnlyList<Contact> SortByState()
    {
        return contacts
            .OrderBy(contact => contact.State)
            .ToList();
    }

    public IReadOnlyList<Contact> SortByZip()
    {
        return contacts
            .OrderBy(contact => contact.Zip)
            .ToList();
    }
    public IReadOnlyList<Contact> SearchByCity(string city)
    {
        return contacts
            .Where(contact =>
                contact.City.Equals(city, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
    
    public IReadOnlyList<Contact> SearchByState(string state)
    {
        return contacts
            .Where(contact =>
                contact.State.Equals(state, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    private static string ReadValue(string message, string currentValue)
    {
        Console.Write(message);
        string? input = Console.ReadLine();

        return string.IsNullOrWhiteSpace(input) ? currentValue : input;
    }
}