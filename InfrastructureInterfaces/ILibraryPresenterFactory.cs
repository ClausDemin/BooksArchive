namespace InfrastructureInterfaces
{
    public interface ILibraryPresenterFactory
    {
        public ILibraryPresenter CreateLibraryPresenter(ILibraryView view);
    }
}
