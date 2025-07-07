using Spectre.Console;

namespace PhonebookProj;

static internal class UserInterface
{
    static internal void ShowPhoneBookTable(List<Person> people)
    {
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Name");
        table.AddColumn("Email");
        table.AddColumn("Phone Number");

        foreach (var p in people)
        {
            table.AddRow(p.Id.ToString(), p.Name, p.Email, p.PhoneNumber);
        }

        AnsiConsole.Write(table);
        Console.WriteLine("Press any key to continue!");
        Console.ReadLine();
    }
}