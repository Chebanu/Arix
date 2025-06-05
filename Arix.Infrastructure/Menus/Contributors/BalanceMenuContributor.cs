using Arix.Infrastructure.Keyboards;
using Arix.Infrastructure.Menus.Interfaces;
using Arix.Infrastructure.Menus.Navigations;

namespace Arix.Infrastructure.Menus.Contributors;

public class BalanceMenuContributor : IMenuContributor
{
    public IEnumerable<MenuNode> GetMenuNodes()
    {
        yield return new MenuNode
        {
            Key = "balance",
            Text = "💰 Balance Menu:",
            Keyboard = Keyboard.BalanceMenu,
            ParentKey = "main_menu"
        };
    }
}