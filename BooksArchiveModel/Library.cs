namespace BooksArchiveModel
{
    public class Library
    {
        private Dictionary<int, Book> _books;
        private Stack<int> _freeIndexes;


        public Library()
        {
            _books = new Dictionary<int, Book>();
            _freeIndexes = new Stack<int>();
            _freeIndexes.Push(0);
        }

        public IEnumerable<Book> Books => _books.Values;

        public IEnumerable<Book> Find<T>(Func<Book, T> function, T query)
        {
            foreach (var book in _books.Values)
            {
                if (function(book).Equals(query))
                {
                    yield return book;
                }
            }
        }

        public void AddBook(Book book)
        {
            _books.Add(_freeIndexes.Pop(), book);

            _freeIndexes.Push(_books.Count);
        }

        public Book RemoveBook(int index)
        {
            if (_books.ContainsKey(index)) 
            {
                var book = _books[index];

                _books[index] = null;
                _freeIndexes.Push(index);

                return book;
            }

            throw new KeyNotFoundException();
        }
    }
}
