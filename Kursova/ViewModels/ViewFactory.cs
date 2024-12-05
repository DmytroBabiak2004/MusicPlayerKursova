// IViewFactory.cs
using Kursova.Views;
using Kursova;
using System.Windows.Controls;
using Kursova.Views;

public interface IViewFactory
{
    UserControl CreateView(string viewName);
}

// ViewFactory.cs

public class ViewFactory : IViewFactory
{
    public UserControl CreateView(string viewName)
    {
        return viewName switch
        {
            "Home" => new HomeView(),
            "AdminTools" => new AdminToolsView(),
            "Login" => new LoginView(),
            "MusicPlayer" => new MusicPlayerView(),
            "UserProfile" => new UserProfileView(),
            _ => new HomeView(), // За замовчуванням
        };
    }
}
