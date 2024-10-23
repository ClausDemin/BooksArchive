using BooksArchiveModel;
using Infrastructure;
using InfrastructureInterfaces;

namespace BooksArchivePresenter
{
    public class LibraryPresenter: ILibraryPresenter
    {
        private Library _library;

        private ILibraryView _libraryView;

        public LibraryPresenter(ILibraryView libraryView) 
        {
            _libraryView = libraryView;
            _library = new Library();
        }

        public IEnumerable<Book> Books => _library.Books;

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

                string successMessage = $"Книга {book} успешно добавлена.";

                _libraryView.PrintMessage(successMessage, ConsoleColor.Green);

                return true;
            }
            catch (ArgumentOutOfRangeException exception)
            {
                _libraryView.PrintMessage("Year must be greater than zero", ConsoleColor.Red);
            }
            catch (ArgumentException) 
            {
                _libraryView.PrintMessage("name or author cannot be empty", ConsoleColor.Red);
            }
            return false;
        }

        public bool TryRemoveBook(int number) 
        {
            try
            {
                var book = _library.RemoveBook(number - 1);
                string successMessage = $"Книга {book} успешно удалена";

                _libraryView.PrintMessage(successMessage, ConsoleColor.Red);

                return true;
            }
            catch (KeyNotFoundException) 
            { 
                _libraryView.PrintMessage($"Книга с номером {number} не найдена", ConsoleColor.Red);

                return false;
            }
        }
    }
}
