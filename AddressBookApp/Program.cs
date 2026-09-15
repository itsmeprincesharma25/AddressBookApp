using AddressBookApp.Exceptions;
using AddressBookApp.Models;
using AddressBookApp.Services;
using AddressBookApp.Validation;

AddressBook addressBook = new();
AddressBookMain addressBookMain = new();
addressBookMain.AddAddressBook(addressBook);

while (true)
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
        
        case "5":
            Console.WriteLine(
                $"Total contacts in all address books: {addressBookMain.GetTotalContactCount()}");
            break;
        
        case "6":
            Console.Write("Enter city to search: ");
            string cityToSearch = Console.ReadLine() ?? "";

            IReadOnlyList<Contact> cityResults =
                addressBookMain.SearchByCity(cityToSearch);

            Console.WriteLine($"Found {cityResults.Count} contact(s):");

            foreach (Contact matchedContact in cityResults)
            {
                Console.WriteLine(matchedContact);
            }

            break;
        
        case "7":
            Console.Write("Enter state to search: ");
            string stateToSearch = Console.ReadLine() ?? "";

            IReadOnlyList<Contact> stateResults =
                addressBookMain.SearchByState(stateToSearch);

            Console.WriteLine($"Found {stateResults.Count} contact(s):");

            foreach (Contact matchedContact in stateResults)
            {
                Console.WriteLine(matchedContact);
            }

            break;
        
        case "8":
            addressBookMain.ViewByCityOrState();
            break;
        case "9":
            addressBookMain.GetCountByCityOrState();
            break;
        
        case "10":
            IReadOnlyList<Contact> sortedContacts = addressBook.SortByName();

            foreach (Contact sortedContact in sortedContacts)
            {
                Console.WriteLine(sortedContact);
            }

            break;

        case "0":
            return;

        default:
            Console.WriteLine("Invalid choice.");
            break;
    }
}