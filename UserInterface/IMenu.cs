namespace UserInterface
{
    public enum MenuType 
    {
        MainMenu, 
        Exit,
        AddCustomer,
        LogIn,
        ShowProducts,
        GetAllLineItemByStore,
        ViewStorefronts,
        OrderMenu,
        PlaceOrderMenu,
    }
    public interface IMenu
    {
        void Menu ();
        MenuType UserChoice ();

    }
}