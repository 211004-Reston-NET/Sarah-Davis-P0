namespace UserInterface
{
    public enum MenuType 
    {
        MainMenu, 
        Exit,
        AddCustomer,
        ShowExcursions,
        ShowClothing,
        ShowProducts
    }
    public interface IMenu
    {
        void Menu ();
        MenuType UserChoice ();

    }
}