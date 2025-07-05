using Microsoft.EntityFrameworkCore;

namespace PhonebookProj;

public class PersonContext : DbContext
{
    public DbSet<Person> Person { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Server=(localdb)\Phonebook;Database=Phonebook;Trusted_Connection=True;"
        ).LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
    }
}

public class Person
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
}
