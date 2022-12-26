using Phonebook.Models;

namespace Phonebook;

public class Phonebook
{
    private const string filepath = "phonebook.txt";

    public Action<string, ConsoleColor> OnDataChange;

    private static Phonebook? instance;

    private Phonebook()
    {
        if (!File.Exists(filepath))
            File.Create(filepath);

    }

    public static Phonebook GetInstance()
    {
        if (instance == null)
            instance = new Phonebook();
        return instance;
    }

    public async Task<bool> CreateContactAsync(Contact contact)
    {
        if (!File.Exists(filepath))
            File.Create(filepath);
        var contacts = await ReadContactAsync();

        if (contacts.Contains(contact))
            return false;

        using (StreamWriter sw = new StreamWriter(filepath, true))
        {
            await sw.WriteLineAsync($"{contact}");
            if (OnDataChange != null)
                OnDataChange(contact.name, ConsoleColor.Green);
        }
        return true;
    }

    public async Task<List<Contact>> ReadContactAsync()
    {
        if (!File.Exists(filepath))
            File.Create(filepath);
        var contacts = new List<Contact>();
        using (StreamReader reader = new StreamReader(filepath))
        {
            string? line;
            while ((line = await reader.ReadLineAsync()) != null)
            {
                if (line == null || line == string.Empty)
                    return contacts;
                var contactData = line.Split(":");
                contacts.Add(new Contact(
                    contactData[0],
                    contactData[1]
                    ));
            }
        }
        return contacts;
    }

    public async Task UpdateContact(int id, Contact contact)
    {
        var contacts = await ReadContactAsync();
        contacts[id] = contact;
        await RewriteFile(contacts);
        if (OnDataChange != null)
            OnDataChange(contacts[id].name, ConsoleColor.Yellow);
    }

    public async Task DeleteContact(int contactId)
    {
        var contacts = await ReadContactAsync();
        var contactToRemove = contacts[contactId];
        contacts.Remove(contactToRemove);
        await RewriteFile(contacts);
        if (OnDataChange != null)
            OnDataChange(contactToRemove.name, ConsoleColor.Red);
    }

    private async Task RewriteFile(List<Contact> contacts)
    {
        using (StreamWriter sw = new StreamWriter(filepath, false))
        {
            foreach (var c in contacts)
            {
                await sw.WriteLineAsync($"{c}");

            }
        }
    }
}