using Arix.Infrastructure.Menus.Interfaces;
using Arix.Infrastructure.Menus.Navigations;

namespace Arix.Infrastructure.Menus.Services;

public class MenuService : IMenuService
{
    private readonly Dictionary<string, MenuNode> _menuMap;

    public MenuService(IEnumerable<IMenuContributor> contributors)
    {
        _menuMap = contributors
            .SelectMany(c => c.GetMenuNodes())
            .ToDictionary(m => m.Key, StringComparer.OrdinalIgnoreCase);
    }

    public MenuNode GetMenu(string key)
    {
        return _menuMap.TryGetValue(key, out var menu)
            ? menu
            : throw new KeyNotFoundException($"Menu '{key}' not found.");
    }
    public bool Exists(string key)
    {
        return _menuMap.ContainsKey(key);
    }
}

