namespace assignment1OOP
{
    enum WeekDays
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }

    enum Season
    {
        Spring,
        Summer,
        Autumn,
        Winter
    }

    [Flags]
    enum Permissions
    {
        None = 0,
        Read = 1,
        Write = 2,
        Delete = 4,
        Execute = 8
    }

    enum Colors
    {
        Red,
        Green,
        Blue,
        Yellow,
        Black,
        White
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine("1.Print all days of the week");
                Console.WriteLine("2.Display season month range");
                Console.WriteLine("3.Manage permissions");
                Console.WriteLine("4.Check if a color is primary");
                Console.WriteLine("5.Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        PrintWeekDays();
                        break;
                    case "2":
                        DisplaySeasonMonths();
                        break;
                    case "3":
                        ManagePermissions();
                        break;
                    case "4":
                        CheckPrimaryColor();
                        break;
                    case "5":
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }

        #region 1-Create an Enum called "WeekDays" with the days of the week (Monday to Sunday) as its members. Then, write a C# program that prints out all the days of the week using this Enum.
        static void PrintWeekDays()
        {
            Console.WriteLine("\nDays of the week:");
            foreach (WeekDays day in Enum.GetValues(typeof(WeekDays)))
            {
                Console.WriteLine(day);
            }
        }
        #endregion
        #region 2-Create an Enum called "Seas on" with the four seasons (Spring, Summer, Autumn, Winter) as its members. Write a C# program that takes a season name as input from the user and displays the corresponding month range for that season. Note range for seasons ( spring march to may , summer june to august , autumn September to November , winter December to February)
        static void DisplaySeasonMonths()
        {
            Console.WriteLine("\nEnter a season name (Spring, Summer, Autumn, Winter): ");
            string input = Console.ReadLine();

            if (Enum.TryParse(input, true, out Season season))
            {
                switch (season)
                {
                    case Season.Spring:
                        Console.WriteLine("March to May");
                        break;
                    case Season.Summer:
                        Console.WriteLine("June to August");
                        break;
                    case Season.Autumn:
                        Console.WriteLine("September to November");
                        break;
                    case Season.Winter:
                        Console.WriteLine("December to February");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid season entered.");
            }
        }
        #endregion
        #region   3-Assign the following Permissions (Read, write, Delete, Execute) in a form of Enum    .Create Variable from previous Enum to Add and Remove Permission from variable, check if specific Permission existed inside variable

        static void ManagePermissions()
        {
            Permissions userPermissions = Permissions.None;

            while (true)
            {
                Console.WriteLine($"\nCurrent Permissions: {userPermissions}");
                Console.WriteLine("1. Add Permission");
                Console.WriteLine("2. Remove Permission");
                Console.WriteLine("3. Check Permission");
                Console.WriteLine("4. Back to Main Menu");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Enter permission to add (Read, Write, Delete, Execute): ");
                        if (Enum.TryParse(Console.ReadLine(), true, out Permissions addPermission))
                        {
                            userPermissions |= addPermission;
                            Console.WriteLine($"{addPermission} added.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid permission.");
                        }
                        break;

                    case "2":
                        Console.WriteLine("Enter permission to remove (Read, Write, Delete, Execute): ");
                        if (Enum.TryParse(Console.ReadLine(), true, out Permissions removePermission))
                        {
                            userPermissions &= ~removePermission;
                            Console.WriteLine($"{removePermission} removed.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid permission.");
                        }
                        break;

                    case "3":
                        Console.WriteLine("Enter permission to check (Read, Write, Delete, Execute): ");
                        if (Enum.TryParse(Console.ReadLine(), true, out Permissions checkPermission))
                        {
                            bool hasPermission = userPermissions.HasFlag(checkPermission);
                            Console.WriteLine($"Has {checkPermission} Permission: {hasPermission}");
                        }
                        else
                        {
                            Console.WriteLine("Invalid permission.");
                        }
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
        #endregion
        #region 4.Create an Enum called "Colors" with the basic colors (Red, Green, Blue) as its members. Write a C# program that takes a color name as input from the user and displays a message indicating whether the input color is a primary color or not.
        static void CheckPrimaryColor()
        {
            Console.WriteLine("\nEnter a color name:");
            string input = Console.ReadLine();

            if (Enum.TryParse(input, true, out Colors color))
            {
                switch (color)
                {
                    case Colors.Red:
                    case Colors.Green:
                    case Colors.Blue:
                        Console.WriteLine($"{color} is a primary color.");
                        break;
                    default:
                        Console.WriteLine($"{color} is not a primary color.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid color entered.");
            }
            #endregion
        }
    }
}
