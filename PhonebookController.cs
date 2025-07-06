using Microsoft.EntityFrameworkCore;
using PhonebookProj;

public class PhonebookController
{
    public List<Person> GetContacts()
    {
        using var db = new PersonContext();
        var people = db.Person.ToList();
        return people;
    }
}
