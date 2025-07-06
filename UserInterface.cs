using Spectre.Console;

namespace PhonebookProj;

static internal class UserInterface
{
    static internal void ShowPhoneBookTable(List<Person> people)
    {
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Name");

        foreach (var p in people)
        {
            table.AddRow(p.Id.ToString(), p.Name);
        }

        AnsiConsole.Write(table);
        Console.ReadLine();
    }
}