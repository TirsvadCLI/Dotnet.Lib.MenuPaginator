using System.Globalization;
using System.Resources;

namespace TirsvadCLI.MenuPaginator;

/// <summary>
/// Menu item record struct.
/// The action to be executed when the menu item is selected when returned.
/// If the action is null, the menu item is not selectable. And is used as a header section.
/// </summary>
/// <param name="Name">The name of the menu item.</param>
/// <param name="Action">The action that will be execute if choose</param>
/// <param name="Role">If user should be able to choose this</param>
public class MenuItem
{
    public string Name { get; private set; }
    public Action? Action { get; private set; } = null;

    public MenuItem(string menuTitle, Action? action)
    {
        Name = menuTitle;
        Action = action;
    }
}

public class MenuPaginator
{
    public MenuItem? menuItem = null;
    public CultureInfo? Culture { get; private set; } = null;
    private readonly ResourceManager _resourceManager = new ResourceManager("TirsvadCLI.MenuPaginator.Properties.Resources", typeof(MenuPaginator).Assembly);

    /// <summary>
    /// Paginates a list of menu items.
    /// </summary>
    /// <param name="menuItems"></param>
    /// <param name="pageSize"></param>
    /// <param name="main">Is this a main menu then esc is equal to exit</param>
    public MenuPaginator(List<MenuItem> menuItems, int pageSize, bool main = false)
    {
        Culture = CultureInfo.CurrentUICulture;
        string errorMessage = ""; // Error message to be displayed
        int pageIndex = 0; // Index of current page
        int x;
        List<int> validIndex; // Index of valid choices this user can make.
        List<MenuItem> newMenuItems; // New menu items
        (int Left, int Top) Position; // For cursor position
        Console.CursorVisible = false;
        int totalPages = (int)Math.Ceiling(menuItems.Count / (double)pageSize); // Total pages
        Position = Console.GetCursorPosition(); // Get the current cursor position
        do
        {
            x = 0;
            validIndex = new List<int>();
            newMenuItems = new List<MenuItem>();
            int indexValidChoice = 0; // Index used for valid choice. Used for display only.
            ClearConsoleFromPosition(Position.Left, Position.Top);
            Console.SetCursorPosition(Position.Left, Position.Top);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                ColorizeString(errorMessage, ConsoleColor.Red);
                errorMessage = "";
                Console.WriteLine("\n");
            }

            var pagedMenuItems = menuItems
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .Select((MenuItem item, int index) =>
                {
                    if (item.Action == null)
                    {
                        ColorizeString(item.Name, ConsoleColor.Green);
                        Console.WriteLine();
                        return item;
                    }
                    else
                    {
                        newMenuItems.Add(item);
                        validIndex.Add(x++);
                        ColorizeString($"F{1 + indexValidChoice++} ", ConsoleColor.Blue);
                        Console.CursorLeft = Position.Left + 4;
                        ColorizeString(item.Name, ConsoleColor.Yellow);
                        Console.WriteLine();
                        return item;
                    }
                })
                .ToList();

            Console.WriteLine();

            if (pageIndex > 0)
            {
                ColorizeString("F11 ", ConsoleColor.Blue);
                Console.Write(GetMsg("Previous page") + ", ");
            }

            if (totalPages > pageIndex + 1)
            {
                ColorizeString("F12 ", ConsoleColor.Blue);
                Console.WriteLine(GetMsg("Next page") + ", ");
            }
            ColorizeString("ESC ", ConsoleColor.Blue);
            if (main)
                Console.WriteLine(GetMsg("Exit"));
            else
                Console.WriteLine(GetMsg("Back"));
            if (totalPages > 1)
                Console.WriteLine($"\n{GetMsg("Page")} {pageIndex + 1} {GetMsg("of")} {totalPages}");

            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Escape)
            {
                if (main)
                    return;
                else
                {
                    menuItem = null;
                    break;
                }
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
                if (selectedIndex < validIndex.Count)
                {
                    menuItem = newMenuItems[validIndex[selectedIndex]];
                    break;
                }
            }
            else
            {
                errorMessage += GetMsg("Error");
                errorMessage += $": {GetMsg("Valid keys are")} F1-F{pagedMenuItems.Count}, ";
                if (pageIndex < totalPages - 1)
                    errorMessage += "F12, ";
                if (pageIndex > 0)
                    errorMessage += "F11, ";
                errorMessage += GetMsg("and") + " ESC";
            }
        } while (true);
    }

    /// <summary>
    /// Colorizes a string with the specified foreground and background colors.
    /// </summary>
    void ColorizeString(string text, ConsoleColor fg_color, ConsoleColor? bg_color = null)
    {
        Console.ForegroundColor = fg_color;
        Console.BackgroundColor = bg_color ?? ConsoleColor.Black;
        Console.Write(text);
        Console.ResetColor();
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

    /// <summary>
    /// Sets the culture for the menu paginator.
    /// </summary>
    /// <param name="culture"></param>
    void SetCulture(CultureInfo culture)
    {
        Culture = culture;
    }

    /// <summary>
    /// Get a string from the resource file.
    /// </summary>
    /// <param name="msg">Msg to be translated</param>
    /// <returns>Translated msg</returns>
    string GetMsg(string msg)
    {
        return _resourceManager.GetString(msg, Culture) ?? msg;
    }
}
