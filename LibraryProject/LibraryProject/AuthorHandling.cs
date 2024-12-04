using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject
{
    internal class AuthorHandling
    {
        public void addAuthor(string surname, string name)
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
        }

        public List<Authors> GetAllAuthors()
        {
            var context = new LibraryProjectEntities1();
            var allAuthors = context.Authors.ToList();
            return allAuthors;
        }
        


    }
}
