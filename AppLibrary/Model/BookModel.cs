namespace AppLibrary.Model;

public class BookModel
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Author { get; set; }
    public string? Genres { get; set; }
    public int Year { get; set; }
    public int Pages { get; set; }
}
