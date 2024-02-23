using DataAccess;
using DataAccess.Entities;

namespace Övning.API.extensions;

public static class AuthorEndpointsExtensions
{
    public static IEndpointRouteBuilder MapAuthorEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/author");

        group.MapGet("/", GetAuthors);

        group.MapPost("/", PostAuthor);

        group.MapPut("/{id}", PutAuthor);

        group.MapDelete("/{id}", DeleteAuthor);


        return app;
    }

    private static Task DeleteAuthor(HttpContext context)
    {
        throw new NotImplementedException();
    }

    private static Task PutAuthor(HttpContext context)
    {
        throw new NotImplementedException();
    }

    private static void PostAuthor(BooksDBContext context, AuthorService service, string name)
    {
        service.AddAuthor(context, name);
    }

    private static List<Author> GetAuthors(AuthorService service, BooksDBContext context)
    {
        return service.GetAllAuthors(context);
    }
}