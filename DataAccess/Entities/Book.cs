namespace DataAccess.Entities;

public class Book
{
    public int Id { get; set; }

    public string Title { get; set; }

    public int Price { get; set; }
    public List<Author> Authors { get; set; } 
}