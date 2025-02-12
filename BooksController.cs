using Spectre.Console;

namespace OOP.LibraryManagementSystem.vcesario;

internal class BooksController
{
    internal void ViewBooks()
    {
        AnsiConsole.MarkupLine("[yellow]List of Books:[/]");

        foreach (var book in MockDatabase.Books)
        {
            AnsiConsole.MarkupLine($"- [cyan]{book}[/]");
        }

        AnsiConsole.MarkupLine("Press Any Key to Continue.");
        Console.ReadKey();
    }

    internal void AddBook()
    {
        /* Spectre's Ask<> method allows us to prompt a message to grab 
                 the user's input. We can pass the type we expect as an answer
                for validation. We're storing the answer in the 'title' variable*/
        var title = AnsiConsole.Ask<string>("Enter the [green]title[/] of the book to add:");

        // checking if the book already exists to avoid duplication.
        if (MockDatabase.Books.Contains(title))
        {
            AnsiConsole.MarkupLine("[red]This book already exists.[/]");
        }
        else
        {
            //if book doesn't exist, add to the list of books.
            MockDatabase.Books.Add(title);
            AnsiConsole.MarkupLine("[green]Book added successfully![/]");
        }

        AnsiConsole.MarkupLine("Press Any Key to Continue.");
        Console.ReadKey();
    }

    internal void DeleteBook()
    {
        // checking if there are any books to delete and letting the user know
        if (MockDatabase.Books.Count == 0)
        {
            AnsiConsole.MarkupLine("[red]No books available to delete.[/]");
            Console.ReadKey();
            return;
        }

        /* showing a list of books and letting the user choose with arrows 
         using SelectionPrompt, similarly to what we do with the menu */
        var bookToDelete = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Select a [red]book[/] to delete:")
            .AddChoices(MockDatabase.Books));

        /* Using the Remove method to delete a book. This method returns a boolean
          that we can use to present a message in case of success or failure.*/
        if (MockDatabase.Books.Remove(bookToDelete))
        {
            AnsiConsole.MarkupLine("[red]Book deleted successfully![/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[red]Book not found.[/]");
        }

        AnsiConsole.MarkupLine("Press Any Key to Continue.");
        Console.ReadKey();
    }
}