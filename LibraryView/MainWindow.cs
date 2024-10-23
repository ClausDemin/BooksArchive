using BooksArchiveModel;
using InfrastructureInterfaces;

namespace LibraryView
{
    public class MainWindow : ILibraryView
    {
        private SwitchableMenu _menu;
        private TextBox _textOutput;
        private bool _isExitRequest;

        public MainWindow(SwitchableMenu menu, TextBox textBox, ILibraryPresenterFactory factory)
        {
            Presenter = factory.CreateLibraryPresenter(this);

            _menu = menu;
            _textOutput = textBox;

            _menu.DrawMenu();
            _textOutput.UpdateText([]);

            _isExitRequest = false;
        }

        public ILibraryPresenter Presenter { get; private set; }

        public string GetUserInput(string message)
        {
            return _textOutput.GetUserInput(message);
        }

        public int GetUserNumber(string message)
        {
            int result = 0;
            bool isParsed = false;

            while (isParsed == false)
            {
                isParsed = int.TryParse(GetUserInput(message), out result);
            }

            return result;
        }

        public void PrintMessage(string message, ConsoleColor errorTextColor = ConsoleColor.Gray)
        {
            _textOutput.UpdateText([message], errorTextColor);
        }

        public void ShowAllBooks()
        {
            ShowBooksFromList(Presenter.Books);
        }

        public void ShowBooksFromList(IEnumerable<Book> books) 
        {
            List<string> bookLines = new List<string>();

            foreach (var book in books)
            {
                bookLines.Add(book.ToString());
            }

            _textOutput.UpdateText(bookLines.ToArray());
        }

        public void Run()
        {
            _menu.DrawMenu();

            while (_isExitRequest == false)
            {
                var controls = Console.ReadKey(true);

                switch (controls.Key)
                {
                    case ConsoleKey.DownArrow:
                        _menu.SwitchToNext();
                        break;

                    case ConsoleKey.UpArrow:
                        _menu.SwitchToPrevious();
                        break;

                    case ConsoleKey.Enter:
                        _menu.ApplyChoice();
                        break;
                }
            }
        }

        public void SwitchMenu(SwitchableMenu nextMenu) 
        { 
            _menu.ClearOutput();

            _menu = nextMenu;
            _menu.DrawMenu();
        }

        public void Close()
        {
            _isExitRequest = true;
        }
    }
}
