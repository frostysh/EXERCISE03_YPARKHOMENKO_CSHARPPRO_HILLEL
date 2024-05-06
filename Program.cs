using System;
using System.Runtime.Intrinsics.X86;

namespace DZ_03
{
    internal class Program
    {
        static void Main(string[] agrs)
        {
            // THE CREATION OF THE FIRST User-CLASS INSTANCE WITH HELP OF AN OBJECT INITIALIZER.
            User user = new User
            {
                FirstName = "YAROSLAV",
                LastName = "PARKHOMENKO",
                Age = 33,
                Gender = UserGender.Male
            };

            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            // TO DISPLAY IN THE CONSOLE AN INFORMATION ABOUT THE FIRST INSTANCE WITH HELP OF THE OVERRIDED METHOD ToString().
            Console.WriteLine(user.ToString());

            Console.WriteLine();

            // THE try-catch-finally CONSTRUCTION TO HANDLE EXCEPTIONS.
            try
            {
                // THE CONSOLE INPUT AND ASSIGNMENT INPUT OF THE STRING PROPERTIES FirstName AND LastName.
                Console.Write("PLEASE, ENTER THE FIRST NAME: ");
                string firstName = Console.ReadLine();
                Console.WriteLine();

                // THE PROGRAM CHECKS INPUT FOR firstName ON EMPTY LINE, ONLY WHITE SPACES AND NULL.
                if (String.IsNullOrWhiteSpace(firstName))
                {
                    throw new FormatException();    // PROGRAM THROWS FORMAT EXCEPTION IN CASE OF firstName INPUT CONSIST OF WHITE SPACES ONLY, OR THE NULL OR AN EMPTY LINE.
                }

                Console.Write("PLEASE, ENTER THE LAST NAME: ");
                string lastName = Console.ReadLine();
                Console.WriteLine();

                // THE PROGRAM CHECKS INPUT FOR lastName ON EMPTY LINE, ONLY WHITE SPACES AND NULL.
                if (String.IsNullOrWhiteSpace(firstName))
                {
                    throw new FormatException();
                }

                // CONSOLE INPUT OF AGE.
                Console.Write("PLEASE, ENTER THE AGE: ");
                byte age = byte.Parse(Console.ReadLine());
                Console.WriteLine();

                // CONSOLE INPUT OF GENDER.
                Console.Write("PLEASE, ENTER THE GENDER (0 — UNKNOWN, 10 — MALE, 11 — FEMALE): ");
                UserGender gender = (UserGender)byte.Parse(Console.ReadLine());
                Console.WriteLine();

                // CREATION OF THE SECOND User-CLASS INSTANCE WITH CONSTRUCTOR WHICH HAS PARAMETER Age = age WITH init IN PROPERTY, INITIALIZATION ONLY ONCE AND THEN Age IS IMMUTABLE.
                // IT IS A COMBINED WAY TO CREATE AN INSTANCE, WE USE THE CONSTRUCTOR WITH A PARAMETER AND THE OBJECT INITIALIZER.
                User user1 = new User(age)
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age,
                    Gender = gender
                };

                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

                // TO SHOW INFORMATION ABOUT THE INSTANCE VIA CONSOLE.
                Console.WriteLine(user1.ToString());
            }
            catch (FormatException formatException)
            {
                Console.WriteLine($"{formatException.Message}");
            }
            catch (OverflowException rangeException)
            {
                Console.WriteLine($"{rangeException.Message}");
            }
            catch (NullReferenceException nullException)        // AN EXCEPTION HANDLE CONSTRUCTION THAT SHOULD COVER COMPILER WARNINGS ABOUT SO-CALLED NULLS... I HOPE.
            {
                Console.WriteLine($"{nullException.Message}");
            }
            catch
            {
                Console.WriteLine("A CRITICAL ERROR APPEARED!!!");
            }
        }
    }
}