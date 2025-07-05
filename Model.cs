using Microsoft.EntityFrameworkCore;

public class PersonContext : DbContext
{
    public required DbSet<Person> Person { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Server=(localdb)\Phonebook;Database=Phonebook;Trusted_Connection=True;"
        );
    }
}

public class Person
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
}
