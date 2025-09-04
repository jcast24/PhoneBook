using PhonebookProj;

namespace PhonebookProj;

public class PhonebookController
{
    public List<Person> GetContacts()
    {
        using var db = new PersonContext();
        var people = db.Person.ToList();
        return people;
    }

    public Person? GetContactById(PersonContext db, int id)
    {
        // var person = db.Person.SingleOrDefault(x => x.Id == id);
        // return person;
        // return db.Person.Where(i => i.Id == id).FirstOrDefault();
        return db.Person.SingleOrDefault(x => x.Id == id);
    }

    public string DeleteContact()
    {
        using var db = new PersonContext();

        Console.WriteLine("Enter id:");
        string idInput = Console.ReadLine() ?? "";
        int id;

        if (int.TryParse(idInput, out id))
        {
            var person = GetContactById(db, id);
            if (person is not null)
            {
                db.Remove(person);
                db.SaveChanges();
                return "User successfully deleted!";
            }
        }
        return "User not found\n";
    }

    public string UpdateContact()
    {
        using var db = new PersonContext();

        Console.WriteLine("Enter id of the contact you would like to update: ");
        string idInput = Console.ReadLine() ?? "";
        int id;

        if (int.TryParse(idInput, out id))
        {
            var person = GetContactById(db, id);
            if (person is not null)
            {
                Console.WriteLine("Update contact");

                Console.WriteLine("Enter new name: ");
                string newName = Console.ReadLine() ?? "";

                Console.WriteLine("Enter new phone number: ");
                string newPhoneNumber = Console.ReadLine() ?? "0";

                Console.WriteLine("Enter new email: ");
                string newEmail = Console.ReadLine() ?? "";

                person.Name = newName;
                person.PhoneNumber = newPhoneNumber;
                person.Email = newEmail;

                db.SaveChanges();
                return "Contact successfully updated!";
            }
        }
        return "User not found\n";
    }

    public string AddContact()
    {
        using var db = new PersonContext();
        var newPerson = new Person();
        string? email;
        string? phoneNumber;

        // Create a new person 
        // add all their info 
        // Create a method that parses both email and phone number into a correct format 
        Console.WriteLine("Name: ");
        string? name = Console.ReadLine();

        Console.WriteLine("Phone Number: ");
        phoneNumber = Console.ReadLine();

        bool checkPhoneNumber = Helper.CheckPhoneNumber(phoneNumber!);
        while (checkPhoneNumber == false)
        {
            Console.WriteLine("Please enter a valid phone number in the format of (xxx) xxx-xxxx: ");
            phoneNumber = Console.ReadLine()!;

            if (Helper.CheckPhoneNumber(phoneNumber) == true)
            {
                break;
            }
        }

        Console.WriteLine("Email: ");
        email = Console.ReadLine()!;

        bool checkEmail = Helper.ValidateEmail(email!);
        while (checkEmail == false)
        {
            Console.WriteLine("Please enter a valid email: ");
            email = Console.ReadLine()!;

            if (Helper.ValidateEmail(email) == true)
            {
                break;
            }
        }

        newPerson.Name = name!;
        newPerson.PhoneNumber = phoneNumber!;
        newPerson.Email = email!;

        db.Add(newPerson);
        db.SaveChanges();

        return "Succssfully added person.\n\n";
    }
}
