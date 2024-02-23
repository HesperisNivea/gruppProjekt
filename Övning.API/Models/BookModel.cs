namespace Övning.API.Models;

public class BookModel
{
    public int Id { get; set; }

    public string Title { get; set; }

    public int Price { get; set; }
    public List<string> AuthorName { get; set; }
}