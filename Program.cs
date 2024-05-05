namespace DZ_03
{
    internal class Program
    {
        static void Main(string[] agrs)
        {
            // CONSOLE INPUT OF AGE.
            Console.Write("PEASE, ENTER THE AGE: ");
            byte age = byte.Parse(Console.ReadLine());

            User user = new User();     // THE CREATION OF User-CLASS INSTANCE WITH DEFAULT CONSTRUCTOR.
            User user1 = new User(age);     // CREATION OF User-CLASS INSTANCE WITH CONSTRUCTOR WHICH HAS PARAMETER Age = age WITH init IN PROPERTY, INITIALIZATION ONLY ONCE AND THEN Age IS IMMUTABLE.
        }
    }
}