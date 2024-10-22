namespace InfrastructureInterfaces
{
    public interface ILibraryView
    {
        public void PrintMessage(string message, ConsoleColor errorTextColor);
        public int GetUserNumber(string message);
    }
}
