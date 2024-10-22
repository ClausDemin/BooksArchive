namespace BooksArchiveModel
{
    public class Library
    {
        private List<Book> _books;

        public Library()
        {
            _books = new List<Book>();
        }

        public IEnumerable<Book> Books => _books;

        public IEnumerable<Book> Find<T>(Func<Book, T> function, T query)
        {
            foreach (var book in _books)
            {
                if (function(book).Equals(query))
                {
                    yield return book;
                }
            }
        }

        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        public void RemoveBook(Book book)
        {
            _books.Remove(book);
        }
    }
}
