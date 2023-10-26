using System.Runtime.Intrinsics.X86;
using System.Text.Json.Serialization;
using static Task4.Task3;

namespace Task4
{
    class Task3
    {
        static void Main(string[] args)
        {
            int id, yearPublish, referenceCode ;
            string author, title;
            BookType bookType;
            string Btype;
            Library lb = new Library();
            Book book = new Book();

            while (true)
            {
                lb.screen();

                int choice = int.Parse(Console.ReadLine());
                Console.WriteLine("Select Book Type");
                Console.WriteLine("1- Reference");
                Console.WriteLine("2- Fiction");
                int choice_1 = int.Parse(Console.ReadLine());   
             
                switch (choice_1)
                {

                    case 1:
                        Console.WriteLine("Enter id");
                         id = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter Title");
                         title = Console.ReadLine();

                        Console.WriteLine("Enter Author");
                         author = Console.ReadLine();

                        Console.WriteLine("Enter Year of Publish");
                         yearPublish = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter Reference Code");
                         referenceCode = int.Parse(Console.ReadLine());

                        Reference refer = new Reference(id, title, author, yearPublish, referenceCode);


                        book.addBook(refer);
                        book.displayBook();
                        break;

                    case 2:
                        Console.WriteLine("Enter id");
                        id = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter Title");
                        title = Console.ReadLine();

                        Console.WriteLine("Enter Author");
                        author = Console.ReadLine();

                        Console.WriteLine("Enter Year of Publish");
                        yearPublish = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter Num of Book Type");
                       Btype=Console.ReadLine();

                      
                        
                        FictionBook fic =new FictionBook(id ,title , author , yearPublish,Btype);

                        book.addBook(fic);
                        book.displayBook();
                        break;
                }
            }


        }


        public class Book : Library
        {
            public int id { get; set; }
            public string title { get; set; }
            public string author { get; set; }
            public int publishYear { get; set; }
            public BookType type { get; set; }

       
            public Book(int _id, string _title, string _author, int _publishYear , BookType _type )
            {
                id = _id;
                title = _title;
                author = _author;
                publishYear = _publishYear;
                type = _type;


            }

            public Book()
            {

            }
            public void addBook(Book b )
            {
                books.Add(b);
             
            }

            public void displayBook()
            {
                Console.WriteLine("Books in Library");

                foreach (Book b in books)
                {
                   
                    if (b is Reference reference)
                    {
                        Console.WriteLine($"Id :  {reference.id} , Title  :  {reference.title} , Author  :   {reference.author}  ,  Publish Year  :   {reference.publishYear}   ,  Reference Code: {reference.ReferenceCode}");

                    }

                    else if (b is FictionBook fiction)
                    {
                        Console.WriteLine($"Id :  {fiction.id} , Title  :  {fiction.title} , Author  :   {fiction.author}  ,  Publish Year  :   {fiction.publishYear}   ,  Type  : {fiction.Genre}");


                    }
                }

            }

        }
        public enum BookType
        {
            Reference, Fiction
        }

        public class Reference : Book
        {
            public  int ReferenceCode { get; set; }

            
            public Reference(int _id, string _title, string _author, int _publishYear,int  _referenceCode) : base(_id, _title, _author, _publishYear ,BookType.Reference)
            {
                ReferenceCode =_referenceCode;  

            }    
        }

        public class FictionBook : Book
        {
            public string Genre { get; set; }

            public FictionBook(int _id, string _title, string _author, int _publishYear, string _type) : base(_id, _title, _author, _publishYear , BookType.Fiction)

            {
                Genre = _type;                
            }

            
        }

        public class Library
        {
           public List<Book> books = new List<Book>();

            public void screen()
            {
                Console.WriteLine("Library System :");
                Console.WriteLine("1- Add Book");
                Console.WriteLine("2- Display Book");
                Console.WriteLine("3- Search Book By ID");
                Console.WriteLine("4- Search Book By Title");
                Console.WriteLine("5- Exit");
                Console.WriteLine("Enter choice");
            }

        }


    }
}
