using BooksArchiveModel;
using Infrastructure;
using InfrastructureInterfaces;

namespace BooksArchivePresenter
{
    public class LibraryPresenter: ILibraryPresenter
    {
        private Library _library;

        private ILibraryView _libraryView;
        private Action<string, ConsoleColor> _messageHandler;
        private ConsoleColor _color;

        public LibraryPresenter(ILibraryView libraryView) 
        {
            _libraryView = libraryView;
            _library = new Library();

            _messageHandler = (string message, ConsoleColor color) =>  _libraryView.PrintMessage(message, _color);
        }

        public IEnumerable<Book> GetBooks()
        {
            return _library.Books;
        }

        public IEnumerable<Book> SearchByAuthor(string author) 
        {
            return _library.Find(x => x.Author, author);
        }

        public IEnumerable<Book> SearchByName(string name) 
        {
            return _library.Find(x => x.Name, name);
        }

        public IEnumerable<Book> SearchByYear(int year) 
        {
            return _library.Find(x => x.Year, year);
        }

        public bool TryAddBook(string author, string name, int year) 
        {
            try
            {
                var book = new Book(author, name, year);
                _library.AddBook(book);

                _color = ConsoleColor.Green;

                string successMessage = $"Книга {book} успешно добавлена.";

                _messageHandler(successMessage, _color);

                return true;
            }
            catch (ArgumentOutOfRangeException exception)
            {
                _color = ConsoleColor.Red;
                _messageHandler("Year must be greater than zero", _color);
            }
            catch (ArgumentException) 
            {
                _color = ConsoleColor.Red;
                _messageHandler("name or author cannot be empty", _color);
            }
            return false;
        }

        public bool TryRemoveBook(int number) 
        {
            try
            {
                var book = _library.RemoveBook(number - 1);
                string successMessage = $"Книга {book} успешно удалена";

                _color = ConsoleColor.Yellow;
                _messageHandler(successMessage, _color);

                return true;
            }
            catch (KeyNotFoundException) 
            { 
                _color = ConsoleColor.Red;
                _messageHandler($"Книга с номером {number} не найдена", _color);

                return false;
            }
        }
    }
}
