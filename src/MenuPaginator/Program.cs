namespace TirsvadCLI.MenuPaginator;

/// <summary>
/// Menu item record struct.
/// The action to be executed when the menu item is selected when returned.
/// If the action is null, the menu item is not selectable. And is used as a header section.
/// </summary>
/// <param name="Name">The name of the menu item.</param>
/// <param name="Action">The action that will be execute if choose</param>
/// <param name="Role">If user should be able to choose this</param>
/// </param>
public class MenuItem
{
    public string Name { get; private set; }
    public object? Action { get; private set; } = null;

    public MenuItem(string menuTitle, object? action)
    {
        Name = menuTitle;
        Action = action;
    }
}

public class MenuPaginator
{
    public MenuItem? menuItem = null;

    /// <summary>
    /// Paginates a list of menu items.
    /// </summary>
    /// <param name="menuItems"></param>
    /// <param name="pageSize"></param>
    /// <param name="main">Is this a main menu then esc is qual to exit</param>
    /// <returns></returns>

    public MenuPaginator(List<MenuItem> menuItems, int pageSize, bool main = false)
    {
        string errorMessage = ""; ///> Error message to be display
        int pageIndex = 0; ///> Index of current page
        int x;
        List<int> validIndex; ///> Index of Valid choice this user can make.
        List<int> validChoice; ///> Index of Valid choice this user can make.
        List<MenuItem> newMenuItems; ///> New menu items
        (int Left, int Top) Position; ///> For cursor position
        Console.CursorVisible = false;
        int totalPages = (int)Math.Ceiling(menuItems.Count / (double)pageSize); ///> Total pages
        Position = Console.GetCursorPosition(); ///> Get the current cursor position
        do
        {
            x = 0;
            validIndex = [];
            validChoice = [];
            newMenuItems = [];
            int indexValidChoice = 0; ///> Index used for valid choice. Used for display only.
            ClearConsoleFromPosition(Position.Left, Position.Top);
            Console.SetCursorPosition(Position.Left, Position.Top);
            if (errorMessage != "")
            {
                Console.WriteLine(AnsiCode.Colorize(errorMessage, AnsiCode.RED));
                errorMessage = "";
            }

            var pagedMenuItems = menuItems
            .Skip(pageIndex * pageSize)
            .Take(pageSize)
            .Select((item, index) =>
            {
                if (item.Action == null)
                {
                    return $"{AnsiCode.Colorize(item.Name, AnsiCode.GREEN)}";
                }
                else
                {
                    newMenuItems.Add(item);
                    validIndex.Add(x++);
                    return AnsiCode.Colorize($"F{1 + indexValidChoice++} ", AnsiCode.BRIGHT_YELLOW) + item.Name;
                }
            })
            .Where(item => item != null)
            .ToList();

            for (int i = 0; i < pagedMenuItems.Count; i++)
            {
                Console.WriteLine(pagedMenuItems[i]);
            }

            Console.WriteLine();

            if (pageIndex > 0)
            {
                Console.Write(AnsiCode.Colorize("F11 ", AnsiCode.BLUE));
                Console.Write("previous page, ");
            }

            if (totalPages > pageIndex + 1)
            {
                Console.Write(AnsiCode.Colorize("F12 ", AnsiCode.BLUE));
                Console.WriteLine("next page, ");
            }
            Console.Write(AnsiCode.Colorize("ESC ", AnsiCode.BLUE));
            if (main)
                Console.WriteLine("Afslut");
            else
                Console.WriteLine("Tilbage");
            Console.WriteLine($"\nSide {pageIndex + 1} af {totalPages}");

            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Escape)
            {
                if (main)
                    Environment.Exit(0);
            }
            else if (key.Key == ConsoleKey.F12 && pageIndex < totalPages - 1)
            {
                pageIndex++;
            }
            else if (key.Key == ConsoleKey.F11 && pageIndex > 0)
            {
                pageIndex--;
            }
            else if (key.Key >= ConsoleKey.F1 && key.Key <= ConsoleKey.F10)
            {
                int selectedIndex = key.Key - ConsoleKey.F1;
                if (selectedIndex <= indexValidChoice - 1)
                {
                    if (validIndex[selectedIndex] != -1)
                        menuItem = newMenuItems[validIndex[selectedIndex]];
                }
                break;
            }
            else
            {
                errorMessage = $"Fejl: Gyldige taster er F1-F{pagedMenuItems.Count} og ";
                if (pageIndex < totalPages - 1)
                    errorMessage += "F12 og ";
                if (pageIndex > 0)
                    errorMessage += "F11 og ";
                errorMessage += "ESC";
            }
        } while (true);
    }




    /// <summary>
    /// Clears the console from a specific position and down.
    /// </summary>
    /// <param name="left">The left position to start clearing from.</param>
    /// <param name="top">The top position to start clearing from.</param>
    void ClearConsoleFromPosition(int left, int top)
    {
        int currentLineCursor = top;
        while (currentLineCursor < Console.WindowHeight)
        {
            Console.SetCursorPosition(left, currentLineCursor);
            Console.Write(new string(' ', Console.WindowWidth - left));
            currentLineCursor++;
        }
    }

}
