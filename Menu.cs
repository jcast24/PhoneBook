using PhonebookProj;
using Spectre.Console;

public class Menu
{
    internal struct MenuOptions
    {
        public const string ListAllContactInfo = "List All Contact Information";
        public const string AddContact = "Add Contact";
        public const string DeleteContact = "Delete Contact";
        public const string UpdateContact = "Update Contact";
        public const string QuitApplication = "Quit";
    }

    public void Run()
    {
        PhonebookController phoneBook = new PhonebookController();

        bool isAppRunning = true;
        while (isAppRunning)
        {
            var option = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Choose an option")
                    .AddChoices(
                        MenuOptions.ListAllContactInfo,
                        MenuOptions.AddContact,
                        MenuOptions.UpdateContact,
                        MenuOptions.DeleteContact,
                        MenuOptions.QuitApplication
                    )
            );

            switch (option)
            {
                case "List All Contact Information":
                    var contacts = phoneBook.GetContacts();
                    UserInterface.ShowPhoneBookTable(contacts);
                    break;
                case "Quit":
                    Console.WriteLine("goodbye!");
                    isAppRunning = false;
                    break;
            }
        }
    }
}
