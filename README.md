# Address Book App

A console-based Address Book application built in C# using .NET.

## Features

- Create and manage contacts
- Validate contact details using regular expressions
- Add multiple contacts
- Edit existing contacts
- Delete contacts
- Prevent duplicate contacts
- Count total contacts
- Search contacts by city or state
- View contacts grouped by city or state
- Count contacts by city or state
- Sort contacts by name
- Sort contacts by city, state, or ZIP code

## Technologies Used

- C#
- .NET 10
- LINQ
- Regular Expressions
- Git & GitHub

## Project Structure

```text
AddressBookApp/
├── Models/
│   └── Contact.cs
├── Services/
│   ├── AddressBook.cs
│   └── AddressBookMain.cs
├── Validation/
│   └── ContactValidator.cs
├── Exceptions/
│   └── InvalidContactException.cs
└── Program.cs
