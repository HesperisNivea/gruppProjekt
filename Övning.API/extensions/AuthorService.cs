using DataAccess.Entities;
using DataAccess;

namespace Övning.API.extensions;

public class AuthorService
{
    public List<Author> Authors { get; set; }

    public List<Author> GetAllAuthors(BooksDBContext context)
    {
        return context.Authors.ToList();
    }

    public void AddAuthor(BooksDBContext context, string name)
    {

        var newAuthor = new Author()
        {
            Name = name,
            Books = new List<Book>()
        };

        context.Authors.Add(newAuthor);
        context.SaveChanges();


    }
}