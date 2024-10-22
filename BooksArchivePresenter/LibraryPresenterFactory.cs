using InfrastructureInterfaces;

namespace BooksArchivePresenter
{
    public class LibraryPresenterFactory: ILibraryPresenterFactory
    {
        public ILibraryPresenter CreateLibraryPresenter(ILibraryView libraryView) 
        { 
            var presenter = new LibraryPresenter(libraryView);

            return presenter;
        }
    }
}
