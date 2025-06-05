using Arix.Infrastructure.Keyboards;
using Arix.Infrastructure.Menus.Interfaces;
using Arix.Infrastructure.Menus.Navigations;

namespace Arix.Infrastructure.Menus.Contributors;

public class ChallengeMenuContributor : IMenuContributor
{
    public IEnumerable<MenuNode> GetMenuNodes()
    {
        yield return new MenuNode
        {
            Key = "challenge",
            Text = "🔥 Challenge:",
            Keyboard = Keyboard.Challenge,
            ParentKey = "main_menu"
        };
    }
}
