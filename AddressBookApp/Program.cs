using AddressBookApp.Models;
using AddressBookApp.Validation;

var contact = new Contact(
    "John",
    "Doe",
    "12 MG Road",
    "Pune",
    "Maharashtra",
    "411001",
    "9876543210",
    "john.doe@mail.com"
);

try
{
    ContactValidator.Validate(contact);
    Console.WriteLine("Contact is valid.");
    Console.WriteLine(contact);
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}