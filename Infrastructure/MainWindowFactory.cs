using InfrastructureInterfaces;
using LibraryView;

namespace Infrastructure
{
    public class MainWindowFactory
    {
        public MainWindow CreateMainWindow(ILibraryPresenterFactory libraryPresenterFactory)
        {
            var mainMenu = new SwitchableMenu();
            var findMenu = new SwitchableMenu();

            var textBox = new TextBox(Console.BufferWidth / 2, 0, Console.BufferWidth / 2);

            var mainWindow = new MainWindow(mainMenu, textBox, libraryPresenterFactory);

            mainMenu.Add
            (
                new MenuItem
                (
                    "Добавить книгу",
                    () => mainWindow.Presenter.TryAddBook
                    (
                        mainWindow.GetUserInput("Введите имя автора книги: "),
                        mainWindow.GetUserInput("Введите название книги: "),
                        mainWindow.GetUserNumber("Введите год издательства: ")
                    )
                )
            );
            mainMenu.Add(new MenuItem("Показать все книги", () => mainWindow.ShowAllBooks()));
            mainMenu.Add(new MenuItem("Поиск", () => mainWindow.SwitchMenu(findMenu)));
            mainMenu.Add(new MenuItem("Закрыть приложение", () => mainWindow.Close()));

            findMenu.Add
            (
                new MenuItem
                (
                    "Искать по автору: ", 
                    () => mainWindow.ShowBooksFromList
                    (
                        mainWindow.Presenter.SearchByAuthor
                        (
                            mainWindow.GetUserInput("Введите имя автора: ")
                        )
                    )
                )
            );            
            findMenu.Add
            (
                new MenuItem
                (
                    "Искать по названию книги: ", 
                    () => mainWindow.ShowBooksFromList
                    (
                        mainWindow.Presenter.SearchByAuthor
                        (
                            mainWindow.GetUserInput("Введите название книги: ")
                        )
                    )
                )
            );            
            findMenu.Add
            (
                new MenuItem
                (
                    "Искать по автору: ", 
                    () => mainWindow.ShowBooksFromList
                    (
                        mainWindow.Presenter.SearchByYear
                        (
                            mainWindow.GetUserNumber("Введите год издания книги: ")
                        )
                    )
                )
            );
            
            findMenu.Add(new MenuItem("Назад...", () => mainWindow.SwitchMenu(mainMenu)));

            return mainWindow;
        }
    }
}
