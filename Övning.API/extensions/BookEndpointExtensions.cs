using DataAccess;
using DataAccess.Entities;
using System.Diagnostics.Metrics;
using Övning.API.Models;

namespace Övning.API.extensions;

public static class BookEndpointExtensions
{
    public static IEndpointRouteBuilder MapBookEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/book");

        group.MapGet("/", GetBooks);

        group.MapPost("/", PostBook);

        group.MapPut("/{id}", PutBook);

        group.MapDelete("/{id}", DeleteBook);

        group.MapPatch("/AddAuthor", AddAuthor);

        return app;
    }

    private static void AddAuthor(BookService service, BooksDBContext context, int authorId, int bookId)
    {
        service.AddAuthor(context, bookId, authorId);

    }


    private static Task DeleteBook(HttpContext context)
    {
        throw new NotImplementedException();
    }

    private static void PutBook(HttpContext context)
    {

    }

    private static void PostBook(BookService service, BooksDBContext context, string title, int price)
    {
        service.AddBook(context, title, price);
    }

    private static List<BookModel> GetBooks(BookService service, BooksDBContext context)
    {
        return service.GetAllBooks(context);
    }

}