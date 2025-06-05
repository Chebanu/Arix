namespace Arix.Infrastructure.Menus.Navigations;

public interface IMenuService
{
    MenuNode GetMenu(string key);
    bool Exists(string key);
}

