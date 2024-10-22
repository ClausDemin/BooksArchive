namespace BooksArchiveModel
{
    public class Book
    {
        private string _author;
        private string _name;

        public Book(string author, string name, int year)
        {
            ArgumentException.ThrowIfNullOrEmpty(author);
            ArgumentException.ThrowIfNullOrEmpty(name);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(year);

            _author = author;
            _name = name;
            Year = year;
        }

        public string Author  => _author;
        public string Name => _name;
        public int Year { get; private set; }

        public override string ToString()
        {
            string bookInfo = $"{Author} \"{Name}\" {Year}";

            return bookInfo;
        }
    }

}
