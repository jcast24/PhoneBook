using Microsoft.EntityFrameworkCore;

namespace PhonebookProj;

public class PersonContext : DbContext
{
    public DbSet<Person> Person { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // optionsBuilder.UseSqlServer(
        //     @"Server=(localdb)\Phonebook;Database=Phonebook;Trusted_Connection=True;"
        // ).LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
        optionsBuilder.UseSqlServer(@"Server=(localdb)\Phonebook;Database=Phonebook;Trusted_Connection=True;");
    }
}

public class Person
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
}
