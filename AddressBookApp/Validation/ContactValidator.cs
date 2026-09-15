using System.Text.RegularExpressions;
using AddressBookApp.Exceptions;
using AddressBookApp.Models;

namespace AddressBookApp.Validation;

public static class ContactValidator
{
    public static void Validate(Contact contact)
    {
        if (!Regex.IsMatch(contact.FirstName, @"^[A-Z][a-zA-Z]{2,}$"))
        {
            throw new InvalidContactException(
                "First name must start with a capital letter and be at least 3 characters.");
        }

        if (!Regex.IsMatch(contact.LastName, @"^[A-Z][a-zA-Z]{2,}$"))
        {
            throw new InvalidContactException(
                "Last name must start with a capital letter and be at least 3 characters.");
        }

        if (!Regex.IsMatch(contact.Address, @"^.{4,}$"))
        {
            throw new InvalidContactException(
                "Address must contain at least 4 characters.");
        }

        if (!Regex.IsMatch(contact.City, @"^.{4,}$"))
        {
            throw new InvalidContactException(
                "City must contain at least 4 characters.");
        }

        if (!Regex.IsMatch(contact.State, @"^.{4,}$"))
        {
            throw new InvalidContactException(
                "State must contain at least 4 characters.");
        }

        if (!Regex.IsMatch(contact.Zip, @"^[0-9]{6}$"))
        {
            throw new InvalidContactException(
                "Zip must contain exactly 6 digits.");
        }

        if (!Regex.IsMatch(contact.PhoneNumber, @"^[0-9]{10}$"))
        {
            throw new InvalidContactException(
                "Phone number must contain exactly 10 digits.");
        }

        if (!Regex.IsMatch(
                contact.Email,
                @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
        {
            throw new InvalidContactException(
                "Email address is not valid.");
        }
    }
}