namespace BooksArchiveModel
{
    public class Book
    {
        public Book(string author, string name, int year)
        {
            ArgumentException.ThrowIfNullOrEmpty(author);
            ArgumentException.ThrowIfNullOrEmpty(name);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(year);

            Author = author;
            Name = name;
            Year = year;
        }

        public string Author { get; private set; }
        public string Name { get; private set; }
        public int Year { get; private set; }

        public override string ToString()
        {
            string bookInfo = $"{Author} \"{Name}\" {Year}";

            return bookInfo;
        }
    }

}
