using AppLibrary.Model;

namespace AppLibrary;

public static class Database
{
    static List<BookModel> books = new List<BookModel> 
    {
        new BookModel {Id = 1, Title = "Harry Potter and the Philosopher's Stone", Author = "J. K. Rowling", Genres = "Fantasy", Pages = 223, Year = 1997},
        new BookModel {Id = 2, Title = "Filosofi Teras", Author = "Henry Manampiring", Genres = "Philosophy", Pages = 346, Year = 2018}
    };

    public static List<BookModel> GetBooks() 
    {
        return books;
    }

    public static BookModel GetBook(int index)
    {
        try
        {
            BookModel? book = books.ElementAtOrDefault(index);
            if (book is null) throw new Exception("Buku tidak ditemukan! Silahkan coba kembali.");

            return book;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public static bool BorrowBook(int index)
    {
        BookModel? borrowedBook = books.ElementAtOrDefault(index);
        if (borrowedBook is null) return false;
        
        books.Remove(borrowedBook);
        return true;
    }
}
