using PhonebookProj;

public class PhonebookController
{
    public List<Person> GetContacts()
    {
        using var db = new PersonContext();
        var people = db.Person.ToList();
        return people;
    }

    public Person? GetContactById(int id)
    {
        using var db = new PersonContext();
        var person = db.Person.SingleOrDefault(x => x.Id == id);
        return person;
    }

    public string DeleteContact()
    {
        using var db = new PersonContext();

        Console.WriteLine("Enter id:");
        string idInput = Console.ReadLine() ?? "";
        int id;

        if (int.TryParse(idInput, out id))
        {
            var person = GetContactById(id);
            if (person is not null)
            {
                db.Remove(person);
                db.SaveChanges();
                return "User successfully deleted!";
            }
        }
        return "User not found\n";
    }

    public string AddContact()
    {
        using var db = new PersonContext();
        var newPerson = new Person();

        // Create a new person 
        // add all their info 
        // Create a method that parses both email and phone number into a correct format 
        Console.WriteLine("Name: ");
        string? name = Console.ReadLine();

        Console.WriteLine("Phone Number: ");
        string? phoneNumber = Console.ReadLine();

        Console.WriteLine("Email: ");
        string? email = Console.ReadLine();

        newPerson.Name = name!;
        newPerson.PhoneNumber = phoneNumber!;
        newPerson.Email = email!;

        db.Add(newPerson);
        db.SaveChanges();

        return "Succssfully added person.\n\n";
    }
}
