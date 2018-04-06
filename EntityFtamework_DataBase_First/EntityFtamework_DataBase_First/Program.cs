using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFtamework_DataBase_First
{
    class Program
    {
        static void AddAuthor(Author author)
        {
            using (Library2Entities db = new Library2Entities())
            {
                db.Author.Add(author);
                db.SaveChanges();
                Console.WriteLine($"New author success added! {author.LastName}");
            }
        }

        static void GetAllAuthors()
        {
            using (Library2Entities db = new Library2Entities())
            {
                var au = db.Author.ToList();
                foreach (var item in au)
                {
                    Console.WriteLine($"{item.FirstName} {item.LastName}");
                }
            }
        }
        //first(), firstOrDefoult
        static Author GetAuthorByName(string fname)
        {
            using (Library2Entities db = new Library2Entities())
            {
                //return (from a in db.Author
                //              where a.FirstName == fname
                //              select a).FirstOrDefault();

                return db.Author.Where(au => au.FirstName == fname).FirstOrDefault(); 
              
            }
        }
        static Author GetAuthorById(int id)
        {
            using (Library2Entities db = new Library2Entities())
            {
                var author = db.Author.Find(id);
                return author;
            }
        }
         
        //Заполнение БД
        static void AddPublisher(Publisher publisher)
        {
            using (Library2Entities db = new Library2Entities())
            {
                Publisher a = db.Publisher.Where(pub => pub.PublisherName == publisher.PublisherName).FirstOrDefault();
                if(a == null)
                {
                    db.Publisher.Add(publisher);
                    db.SaveChanges();
                    Console.WriteLine($"New publisher aded!");
                }
            }
        }

        static void AddBook(Book book)
        {
            using(Library2Entities db = new Library2Entities())
            {
                db.Book.Add(book);
                db.SaveChanges();
                Console.WriteLine($"New book aded!");
            }
        }

        static void Init()
        {
            Author author = new Author { FirstName = "Ray", LastName = "Bradbury" };
            AddAuthor(author);
            author = new Author { FirstName = "Harry", LastName = "Harrison" };
            AddAuthor(author);
            author = new Author { FirstName = "Clifford", LastName = "Simak" };
            AddAuthor(author);

            Publisher publisher = new Publisher { PublisherName = "R", Address = "Kyiv" };
            AddPublisher(publisher);
            publisher = new Publisher { PublisherName = "E", Address = "Kyiv" };
            AddPublisher(publisher);
            publisher = new Publisher { PublisherName = "B", Address = "Krivoy Rog" };
            AddPublisher(publisher);

            Book book = new Book { Title = "Way Station", IdPublisher = 1, IdAuthor = 1, Pages = 234, Price = 678 };
            AddBook(book);
            book = new Book { Title = "Way Station", IdPublisher = 2, IdAuthor = 1, Pages = 245, Price = 4545 };
            AddBook(book);
            book = new Book { Title = "Way Station", IdPublisher = 1, IdAuthor = 2, Pages = 234, Price = 234 };
            AddBook(book);
        }
        //Свойства навигации
        static void GetBook()
        {
            using (Library2Entities db = new Library2Entities())
            {
                var books = db.Book.OrderBy(b => b.Title).ToList();
                foreach (var book in books)
                {
                    Console.WriteLine($"Book: {book.Title}, Price: {book.Price}, Author: {book.Author.FirstName}");
                }
            }
        }

        static void Main(string[] args)
        {

            //Init();
            //GetAllAuthors();
            GetBook();
            Console.Read();
        }
    }
}
