using TirsvadCLI.MenuPaginator;

namespace Example;

internal class Example
{

    static void SomeAction()
    {
        Console.Clear();
        Console.WriteLine("Some action");
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
    }

    static void SomeOtherAction()
    {
        Console.Clear();
        Console.WriteLine("Some other action");
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
    }

    static void SomeActionWithParameter(string parameter)
    {
        Console.Clear();
        Console.WriteLine($"Some action with parameter: {parameter}");
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
    }

    /// <summary>
    /// Example of a menu with only one page
    /// </summary>
    static void MenuExample1()
    {
        Console.Clear();
        Console.WriteLine("Example of a menu\n");
        List<MenuItem> menuItems = new()
        {
            new MenuItem("Some action to do", (Action)SomeAction)
        };
        MenuPaginator menu = new(menuItems, 10, true);
        if (menu.menuItem != null && menu.menuItem.Action is Action action)
        {
            action();
        }
    }

    /// <summary>
    /// Example of a menu with more than one page
    /// Having a category in the menu
    /// Limit to 10 items per page
    /// </summary>
    static void MenuExample2()
    {
        Console.Clear();
        Console.WriteLine("Example of a menu with more than one page\n");

        List<MenuItem> menuItems = new()
        {
            new MenuItem("Some action to do", (Action)SomeAction),
            new MenuItem("Some action action to do", (Action)SomeOtherAction),
            new MenuItem("Some action to do", (Action)SomeAction),
            new MenuItem("Some action action to do", (Action)SomeOtherAction),
            new MenuItem("Some action to do", (Action)SomeAction),
            new MenuItem("A category", null),
            new MenuItem("Some action to do", (Action)SomeAction),
            new MenuItem("Some action action to do", (Action)SomeOtherAction),
            new MenuItem("Some action to do", (Action)SomeAction),
            new MenuItem("Some action action to do", (Action)SomeOtherAction),
            new MenuItem("Some action to do", (Action)SomeAction),
            new MenuItem("Some action action to do", new Action(() => { SomeActionWithParameter("Hello"); })),
        };
        MenuPaginator menu = new(menuItems, 10);
        if (menu.menuItem != null && menu.menuItem.Action is Action action)
        {
            action();
        }
    }

    static void Main(string[] args)
    {
        MenuExample1();
        MenuExample2();
    }
}
