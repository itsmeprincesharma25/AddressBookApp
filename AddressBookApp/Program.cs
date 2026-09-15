using AddressBookApp.Exceptions;
using AddressBookApp.Models;
using AddressBookApp.Services;
using AddressBookApp.Validation;

AddressBook addressBook = new();

while (true)
{
    Console.WriteLine("\n1. Add Contact");
    Console.WriteLine("2. Show All Contacts");
    Console.WriteLine("3. Edit Contact");
    Console.WriteLine("4. Delete Contact");
    Console.WriteLine("0. Exit");
    Console.Write("Enter your choice: ");

    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
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

            Contact contact = new(
                firstName,
                lastName,
                address,
                city,
                state,
                zip,
                phoneNumber,
                email
            );

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

            break;

        case "2":
            addressBook.PrintAll();
            break;
        
        case "3":
            Console.Write("Enter first name to edit: ");
            string editFirstName = Console.ReadLine() ?? "";

            Console.Write("Enter last name to edit: ");
            string editLastName = Console.ReadLine() ?? "";

            addressBook.EditContact(editFirstName, editLastName);
            break;
        
        case "4":
            Console.Write("Enter first name to delete: ");
            string deleteFirstName = Console.ReadLine() ?? "";

            Console.Write("Enter last name to delete: ");
            string deleteLastName = Console.ReadLine() ?? "";

            addressBook.DeleteContact(deleteFirstName, deleteLastName);
            break;

        case "0":
            return;

        default:
            Console.WriteLine("Invalid choice.");
            break;
    }
}