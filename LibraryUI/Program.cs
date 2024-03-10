using System.Security.Cryptography;
using AppLibrary;
using AppLibrary.Model;

bool flag = false;
do
{
    List<BookModel> books = Database.GetBooks();

    Console.WriteLine($"Selamat Datang di Perpustakaan kami!{Environment.NewLine}");
    Console.WriteLine("Beberapa buku yang tersedia pada Perpustakaan ini yaitu : ");

    for (int i = 0; i < books.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {books[i].Title} by {books[i].Author} ({books[i].Year} - {books[i].Genres} - {books[i].Pages} pages)");
    }

    Console.WriteLine();
    Console.Write("Apakah Anda ingin meminjam sebuah buku? (y/n) : ");
    string? isBorrow = Console.ReadLine();
    Console.WriteLine();

    if (isBorrow is "y") 
    {
        Console.WriteLine("Silahkan isi data peminjam dan nomor urutan buku yang ingin Anda pinjam pada form berikut ini. **Wajib dilengkapi");
        bool formError = false;
        do
        {
            try
            {
                Console.Write("**Nama Lengkap : ");
                string? fullName = Console.ReadLine();
                if (fullName is null || fullName.Equals(string.Empty)) throw new Exception("Aduh! Nama Lengkap harus dilengkapi, silahkan coba kembali.");

                Console.Write("**No. HP : ");
                string? phoneNumber = Console.ReadLine();
                if (phoneNumber is null || phoneNumber.Equals(string.Empty)) throw new Exception("Aduh! No. HP harus dilengkapi, silahkan coba kembali.");

                Console.Write("Umur : ");
                string? age = Console.ReadLine();
            
                Console.Write("**Nomor urutan buku : ");
                string? index = Console.ReadLine();
                if (index is null || index.Equals(string.Empty)) throw new Exception("Aduh! Nomor urutan buku harus dilengkapi, silahkan coba kembali.");
            
                BookModel book = Database.GetBook(Convert.ToInt32(index) - 1);
                bool savedToDatabase = Database.BorrowBook(Convert.ToInt32(index) - 1);

                if (savedToDatabase)
                {
                    Console.WriteLine($"Peminjaman buku berhasil! Semoga buku {book.Title} menyenangkan!");
                    formError = false;
                    flag = true;
                    Thread.Sleep(2500);
                    Console.Clear();
                }
                else
                {
                    throw new Exception("Aduh! Sepertinya terdapat kesalahan. Peminjaman buku gagal. Silahkan coba kembali.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine(ex.Message);
                formError = true;
            }
        } while (formError is true);
    }
    else 
    {
        flag = false;
        Console.WriteLine("Anda akan meninggalkan Perpustakaan kami, silahkan tekan apapun pada keyboard. Sampai Jumpa!");
        Console.ReadKey(true);
    }
} while (flag is true);