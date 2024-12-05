using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace LibraryProject
{
    internal class BooksHandling
    {
        public static async Task AddBookAsync(string bookTitle, DateTime publishedDate, string bookContent, int authorID)
        {
            using (var context = new LibraryProjectEntities1())
            {
                int newBiggestID = (context.Books.Max(b => (int?)b.BookID) ?? 0) + 1;
                var newBook = new Books()
                {
                    BookID = newBiggestID,
                    BookContent = bookContent,
                    BookTitle = bookTitle,
                    AuthorID = authorID,
                    PublishedDate = publishedDate,
                };
                context.Books.Add(newBook);
                await context.SaveChangesAsync();
            }
            Console.WriteLine("Press any key to continue, the book was added.");
            Console.ReadLine();
        }


        public static void ListAllBooks()
        {
            var context = new LibraryProjectEntities1();
            var allBooks = context.Books.ToList();
            Console.WriteLine("This is a list of all books in the library:");
            foreach (var book in allBooks)
            {
                Console.WriteLine(book.BookID + " " + book.BookTitle + " " + book.PublishedDate);
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }

        public static void DisplayBook(int bookID)
        {
            var context = new LibraryProjectEntities1();
            var book = context.Books.Find(bookID);
            Console.Clear();
            Console.WriteLine("Title: " + book.BookTitle + " Date Published: " + book.PublishedDate + " Book ID: " + book.BookID);
            Console.WriteLine(book.BookContent);
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }

        public static void RemoveBook()
        {
            Console.Clear();
            ListAllBooks();
            Console.WriteLine("Please choose a book you would like to remove: ");
            int IDbookToRemove = Int32.Parse(Console.ReadLine());
            var context = new LibraryProjectEntities1();
            var bookToRemove = context.Books.Find(IDbookToRemove);
            Console.WriteLine("You are trying to remove: " + bookToRemove.BookTitle + " Are you sure you want to remove this book? (y/n)");
            Console.WriteLine("NOTE: This will not remove the author or any other book");
            string decision = Console.ReadLine();

            if (decision == "y")
            {
                try
                {
                    context.Books.Remove(bookToRemove);
                    context.SaveChanges();
                    Console.WriteLine("The book you chose was removed");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e + " The book you chose couldnt be removed due to an error");
                }
            }
            if (decision == "n")
            {
                Console.WriteLine("Cancelled book removal");
            }
            else
            {
                Console.WriteLine("The option you chose is neither Y or N, please choose a valid option");
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }
    }
}
