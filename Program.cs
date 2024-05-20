using System;
using System.Runtime.Intrinsics.X86;
using System.Text.RegularExpressions;   // TO USE REGULAR EXPRESSION METHODS FROM C#-LIBRARIES.

// HILLEL, C# PRO COURSE, TEACHER: MARIIA DZIVINSKA
// HOMEWORK 03: "Console program with objects"
// STUDENT: PARKHOMENKO YAROSLAV
// DATE: 06-MAY-2024

namespace DZ_03
{
    internal class Program
    {
        // FIELDS

        // PROGRAM CLASS USES PRIVATE CONSTANT FOR REG EXPRESSIONS VALIDATIONS.
        private const int _timeoutRegexCheckup = 500;   // MAXIMUM ALLOWED VALIDATION TIME.
        private const string _patternNameRegex = @"(\A[a-z])|(\W)|(\d)|(_)";
        // USED REGULAR EXPRESSIONS EXPLANATIONS:
        // \A — WORK WITH THE FIRST CHARACTER IN LINE.
        // (\A[a-z]) — IF THE FIRST CHARACTER IS ALPHABETIC LOWER CASE LATIN, THEN RETURN TRUE.
        // (\W) — IF IN THE LINE EXIST ANY OF CHARACTERS DIFFERENT FROM "_", "[a - z]", "[A - Z]", "[0 - 9]", THEN RETURN TRUE.
        // (\d) — IF IN THE LINE EXIST CHARACTERS "[0 - 9]", THEN RETURN TRUE.
        // (_) — IF IN THE LINE EXIST CHARACTER "_", THEN RETURN TRUE.
        // | — LOGICALC "OR" OPERATOR.

        // METHODS
        
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

            Console.WriteLine("THE OBJECT INITIALIZER USED INSTEAD OF THE DEFAULT CONSTRUCTOR OF User CLASS!");

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

                // IF THE firstName IS TOO LONG, THEN THROW THE EXCEPTION.
                if (firstName.Length >= 64)
                {
                    throw new OverflowException();
                }

                // A VALIDATION WITH HELP OF REGULAR EXPRESSIONS.
                // JUST TO MAKE THE SOURCE CODE MORE READABLE, LOCALIZE REGEX IN THE BOOL VALUE.
                // 0 — MEANS NO OPTION IS SET.
                bool nameIsMatch = Regex.IsMatch(firstName, _patternNameRegex, 0,  TimeSpan.FromMilliseconds(_timeoutRegexCheckup));
                // IF THE NAME MATCH PATTERN, TERMINATE THE PROGRAM.
                if (nameIsMatch)
                {
                    throw new FormatException();
                }

                // LAST NAME SECTION.
                Console.Write("PLEASE, ENTER THE LAST NAME: ");
                string lastName = Console.ReadLine();
                Console.WriteLine();

                // THE PROGRAM CHECKS INPUT FOR lastName ON EMPTY LINE, ONLY WHITE SPACES AND NULL.
                if (String.IsNullOrWhiteSpace(firstName))
                {
                    throw new FormatException();
                }

                // IF THE lastName IS TOO LONG, THEN THROW THE EXCEPTION.
                if (lastName.Length >= 64)
                {
                    throw new OverflowException();
                }

                // REGEX VALIDATION OF LAST NAME.
                nameIsMatch = Regex.IsMatch(lastName, _patternNameRegex, 0, TimeSpan.FromMilliseconds(_timeoutRegexCheckup));
                // IF THE NAME MATCH PATTERN, TERMINATE THE PROGRAM.
                if (nameIsMatch)
                {
                    throw new FormatException();
                }

                // CONSOLE INPUT OF AGE.
                Console.Write("PLEASE, ENTER THE AGE: ");
                byte age = byte.Parse(Console.ReadLine());
                Console.WriteLine();

                // IF AGE IS TOO OLD, OR TOO YOUNG THEN TERMINATE THE PROGRAM.
                if ((age >= 110) || (age <= 3))
                {
                    throw new OverflowException();
                }

                // CONSOLE INPUT OF GENDER.
                Console.Write("PLEASE, ENTER THE GENDER (0 — UNKNOWN, 10 — MALE, 11 — FEMALE): ");
                UserGender gender = (UserGender)byte.Parse(Console.ReadLine());
                Console.WriteLine();

                // IF GENDER IS SOMETHING DIFFERENT FROM GENDER ENUMERATION, TERMINATE THE PROGRAM.
                // IF IsDefined() METHOD RETURN TRUE — THE PROPER GENDER SELECTED FROM UserGender ENUMERATION, AND DUE TO THE NEGATION OPERATOR THE PROGRAM AVOIDS THE CODE INSIDE if() CONSTRUCTION. ELSE TERMINATE THE PROGRAM.
                // https://learn.microsoft.com/en-us/dotnet/api/system.enum.isdefined?view=net-8.0
                if (!Enum.IsDefined(typeof(UserGender), gender))
                {
                    throw new OverflowException();
                }

                // CREATION OF THE SECOND User-CLASS INSTANCE WITH CONSTRUCTOR WHICH HAS PARAMETER Age = age WITH init IN PROPERTY, INITIALIZATION ONLY ONCE AND THEN Age IS IMMUTABLE.
                // IT IS A COMBINED WAY TO CREATE AN INSTANCE, WE USE THE CONSTRUCTOR WITH A PARAMETER AND THE OBJECT INITIALIZER.
                User user1 = new User(age)
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Gender = gender
                };

                Console.WriteLine("THE PARAMETRIC CONSTRUCTOR OF User INITIALIZED!");

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