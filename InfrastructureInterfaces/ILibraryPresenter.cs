using BooksArchiveModel;

namespace InfrastructureInterfaces
{
    public interface ILibraryPresenter
    {
        public bool TryAddBook(string author, string name, int year);

        bool TryRemoveBook(int index);

        public IEnumerable<Book> GetBooks();

        public IEnumerable<Book> SearchByAuthor(string author);

        public IEnumerable<Book> SearchByName(string name);

        public IEnumerable<Book> SearchByYear(int year);

    }
}
