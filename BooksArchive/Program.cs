using BooksArchivePresenter;
using Infrastructure;

namespace LibraryView
{
    public static class Program
    {
        public static void Main()
        {
            Console.CursorVisible = false;

            var mainWindowFactory = new MainWindowFactory();
            var presenterFactory = new LibraryPresenterFactory();

            var mainWindow = mainWindowFactory.CreateMainWindow(presenterFactory);

            mainWindow.Run();
        }
    }
}
