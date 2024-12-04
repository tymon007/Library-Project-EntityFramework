using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject
{
    internal class UIHandling
    {
        public static void mainMenu()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Welcome to the library, what would you like to do?");
            Console.WriteLine("1. I would like to manage or display authors");
            Console.WriteLine("2. I would like to manage or display books");
            Console.WriteLine("3. Exit");
            Console.WriteLine("--------------------------------------------------");
            int choice = Int32.Parse(Console.ReadLine());
            if (choice == 1)
            {
                authorsMenu();
            }
            else if (choice == 2)
            {
                booksMenu();
            }
            else if (choice == 3)
            {
                Environment.Exit(0);
            }
            else 
            {
                Console.WriteLine("The number you chose does not correspond to any action. Please choose a correct number to proceed.");
            }

        }

        public static void authorsMenu()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("This is the authors menu, what would you like to do?");
            Console.WriteLine("1. I would like to add an author");
            Console.WriteLine("2. I would like to list all authors");
            Console.WriteLine("3. I would like to remove an author");
            Console.WriteLine("4. Go Back");
            Console.WriteLine("--------------------------------------------------");

            int choice = Int32.Parse(Console.ReadLine());

            if (choice == 1)
            {
                Console.WriteLine("Please input the surname of the author");
                string authorSurname = Console.ReadLine();
                Console.WriteLine("Please input the name of the author");
                string authorName = Console.ReadLine();
                try
                {
                    AuthorHandling.AddAuthor(authorSurname, authorName);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e + " Adding author failed.");
                }
            }
            else if (choice == 2)
            {
                AuthorHandling.ListAllAuthors();
            }
            else if (choice == 3)
            {
                AuthorHandling.RemoveAuthor();
            }
            else if (choice == 4)
            {
                mainMenu();
            }
            else
            {
                Console.WriteLine("The number you chose does not correspond to any action. Please choose a correct number to proceed.");
            }
        }

        public static void booksMenu()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("This is the books menu, what would you like to do?");
            Console.WriteLine("1. I would like to add a book");
            Console.WriteLine("2. I would like to remove a book");
            Console.WriteLine("3. I would like list all books");
            Console.WriteLine("4. I would like to read a book");
            Console.WriteLine("5. Go back");
            Console.WriteLine("--------------------------------------------------");

            int choice = Int32.Parse(Console.ReadLine());

            if (choice == 1)
            {
                AuthorHandling.ListAllAuthors();
                Console.WriteLine("Please input the ID of the author");
                int bookAuthorID = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Please input title of the book");
                string bookTitle = Console.ReadLine();
                Console.WriteLine("Please input the contents of the book");
                string bookContent = Console.ReadLine();
                Console.WriteLine("Please input the publish date of the book");

                Console.Write("Enter a month: ");
                int month = Int32.Parse(Console.ReadLine());
                Console.Write("Enter a day: ");
                int day = Int32.Parse(Console.ReadLine());
                Console.Write("Enter a year: ");
                int year = Int32.Parse(Console.ReadLine());
                DateTime bookDate = new DateTime(year, month, day);

                try
                {
                    BooksHandling.AddBook(bookTitle, bookDate, bookContent, bookAuthorID);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e + " Adding author failed.");
                }
            }
            else if (choice == 2)
            {
                BooksHandling.RemoveBook();
            }
            else if (choice == 3)
            {
                BooksHandling.ListAllBooks();
            }
            else if (choice == 4)
            {
                BooksHandling.ListAllBooks();
                Console.WriteLine("Choose the ID of the book you would like to read: ");
                int bookID = Int32.Parse(Console.ReadLine());
                try
                {
                    BooksHandling.DisplayBook(bookID);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e + "There is no book with the ID you chose, or another error happened during processing");
                }
            }
            else if (choice == 5)
            {
                mainMenu();
            }
            else
            {
                Console.WriteLine("The number you chose does not correspond to any action. Please choose a correct number to proceed.");
            }
        }
    }
}
