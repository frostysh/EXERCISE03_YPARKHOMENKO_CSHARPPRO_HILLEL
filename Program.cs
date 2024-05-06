namespace DZ_03
{
    internal class Program
    {
        static void Main(string[] agrs)
        {
            // CONSOLE INPUT OF AGE.
            Console.Write("PEASE, ENTER THE AGE: ");
            User user1 = new User(byte.Parse(Console.ReadLine()));     // CREATION OF User-CLASS INSTANCE WITH CONSTRUCTOR WHICH HAS PARAMETER Age = age WITH init IN PROPERTY, INITIALIZATION ONLY ONCE AND THEN Age IS IMMUTABLE.
            Console.WriteLine();

            User user = new User();     // THE CREATION OF User-CLASS INSTANCE WITH DEFAULT CONSTRUCTOR.
            Console.WriteLine();

            // CONSOLE INPUT OF GENDER AND ASSIGNMENT IT TO THE INSTANCE OF THE CLASS.
            Console.Write("PLEASE, ENTER THE GENDER (0 — UNKNOWN, 10 — MALE, 11 — FEMALE): ");
            user1.Gender = (UserGender)byte.Parse(Console.ReadLine());
            Console.WriteLine();

            // THE CONSOLE INPUT AND ASSIGNMENT INPUT OF THE STRING PROPERTIES FirstName AND LastName.
            Console.Write("PLEASE, ENTER THE FIRST NAME: ");
            user1.FirstName = Console.ReadLine();
            Console.WriteLine();

            Console.Write("PLEASE, ENTER THE LAST NAME: ");
            user1.LastName = Console.ReadLine();
        }
    }
}