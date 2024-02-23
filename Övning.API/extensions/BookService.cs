using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Övning.API.Models;

namespace Övning.API.extensions
{
    public class BookService
    {

        public List<BookModel> GetAllBooks(BooksDBContext context)
        {
            var allBooks = context.Books.Include(b => b.Authors).ToList();

            var bookModels = new List<BookModel>();

            foreach (var book in allBooks)
            {
                bookModels.Add(new BookModel()
                {
                    Id = book.Id,
                    Title = book.Title,
                    Price = book.Price,
                    AuthorName = book.Authors.Select(a => a.Name).ToList(),
                });
            }

            return bookModels;
        }

        public void AddBook(BooksDBContext context, string title, int price)
        {

            var newBook = new Book()
            {
                
                Title = title,
                Price = price,
                Authors = new List<Author>()
            };

            context.Books.Add(newBook);
            context.SaveChanges();

        }

        public void AddAuthor(BooksDBContext context, int bookId, int authorId)
        {
            var author = context.Authors.SingleOrDefault(a => a.Id == authorId);
            var book = context.Books.Include(b => b.Authors).SingleOrDefault(b => b.Id == bookId);

            if (author  is null || book is null)
            {
                throw new ArgumentException("Author could not be found");
            }

            
            book.Authors.Add(author);
            context.SaveChanges();

        }
    }
}
