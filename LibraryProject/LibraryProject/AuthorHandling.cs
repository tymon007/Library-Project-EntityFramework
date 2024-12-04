using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject
{
    internal class AuthorHandling
    {
        public static void AddAuthor(string surname, string name)
        {
            var context = new LibraryProjectEntities1();
            var allAuthors = context.Authors.ToList();
            int biggestID = 0;
            foreach (var author in allAuthors)
            {
                if (author.AuthorID == null)
                {
                    biggestID = 0;
                }
                else if (author.AuthorID > biggestID)
                {
                    biggestID = author.AuthorID;
                }
            }
            int newBiggestID = biggestID + 1;

            var newAuthor = new Authors
            {
                AuthorName = name,
                AuthorSurname = surname,
                AuthorID = newBiggestID
            };

            context.Authors.Add(newAuthor);
            context.SaveChanges();

            Console.WriteLine("Press any key to continue, the author was added");
            Console.ReadLine();
        }

        public static List<Authors> getAllAuthors()
        {
            var context = new LibraryProjectEntities1();
            if (context.Authors != null)
            {
                return context.Authors.ToList();
            }
            else
            {
                return null;
            }
        }

        public static void ListAllAuthors()
        {
            var context = new LibraryProjectEntities1();
            var allAuthors = context.Authors.ToList();
            foreach (var author in allAuthors)
            {
                Console.WriteLine(author.AuthorID + " " + author.AuthorName + " " + author.AuthorSurname);
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }

        public static void RemoveAuthor()
        {
            ListAllAuthors();
            Console.WriteLine("Please choose an author you would like to remove: ");
            int IDauthorToRemove = Int32.Parse(Console.ReadLine());
            var context = new LibraryProjectEntities1();
            var authorToRemove = context.Authors.Find(IDauthorToRemove);
            Console.WriteLine("You are trying to remove author: " + authorToRemove.AuthorName + " " + authorToRemove.AuthorSurname + " Are you sure you want to remove this author? (y/n)");
            Console.WriteLine("NOTE: This will also REMOVE ALL BOOKS ASSOCIATED WITH THIS AUTHOR");
            string decision = Console.ReadLine();

            if (decision == "y")
            {
                //Try to remake it as a query to get all books of the author in one function
                List<Books> allBooks = context.Books.ToList();

                foreach (Books book in allBooks)
                {
                    if (book.AuthorID == IDauthorToRemove)
                    {
                        context.Books.Remove(book);
                    }
                }

                context.Authors.Remove(authorToRemove);
                context.SaveChanges();
            }
            if (decision == "n")
            {
                Console.WriteLine("Cancelled book removal");
            }
            else
            {
                Console.WriteLine("The option you chose is neither Y or N, please choose a valid option");
            }
        }

    }
}
