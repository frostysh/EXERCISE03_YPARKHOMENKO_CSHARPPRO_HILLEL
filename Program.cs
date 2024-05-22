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

        // MAXIMUM ALLOWED VALIDATION TIME.
        private const int _timeoutRegexCheckup = 500;       
        private const string _patternNameRegex = @"([^a-zA-z\s\'\-])|(\b\s+\b)|(\`)|((\'|\-){2,})|(\s(\'|\-))|((\'|\-)\s)|((\'|\-)$)|(^(\'|\-))|(_)";
        #region
        // USED REGULAR EXPRESSIONS EXPLANATIONS:
        // ([^a-zA-z\s]) — MATCHES ANY CHARACTER EXCEPT "`", LETTERS, SPACES, UNDERSCORE "_".
        // (\b\s+\b) — MATCHES ONE OR MORE SPACES INSIDE THE WORD BOUNDARIES, FOR AN EXAMPLE "YARO  SLAV".
        // (\`) — MATCHES "`" CHARACTER.
        // (\'{2,}) — MATCHES TWO OR MORE "'" CHARACTER IN SEQUENCE.
        // (\s\')|(\`\s) — MATCH "'" AND A WHITESPACE CHARACTER IN SEQUENCE.
        // (^\`) — MATCHES "'" IN THE FIRST POSITION.
        // (\-) — MATCHES "-".
        // (_) — MATCHES UNDERSCORE "_".
        // | — LOGICAL "OR" OPERATOR.
        #endregion

        // METHODS

        static void Main(string[] agrs)
        {
            User user = new User
            {
                FirstName = "YAROSLAV",
                LastName = "PARKHOMENKO",
                Age = 33,
                Gender = UserGender.male
            };

            Console.WriteLine("THE OBJECT INITIALIZER USED INSTEAD OF THE DEFAULT CONSTRUCTOR OF User CLASS!");

            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            Console.WriteLine(user.ToString());

            Console.WriteLine();

            // THE try-catch-finally CONSTRUCTION TO HANDLE EXCEPTIONS.
            try
            {   
                // INPUT AND VALIDATION OF firstName AND lastName
                
                Console.Write("PLEASE, ENTER THE FIRST NAME: ");
                string firstName = Console.ReadLine();
                Console.WriteLine();

                ValidateName(firstName);
                firstName = DeleteSpacesAfterBefore(firstName);

                Console.Write("PLEASE, ENTER THE LAST NAME: ");
                string lastName = Console.ReadLine();
                Console.WriteLine();

                ValidateName(lastName);
                lastName = DeleteSpacesAfterBefore(lastName);

                // CONSOLE INPUT OF AGE.
                Console.Write("PLEASE, ENTER THE AGE: ");
                byte age = byte.Parse(Console.ReadLine());
                Console.WriteLine();

                // IF AGE IS TOO OLD, OR TOO YOUNG THEN TERMINATE THE PROGRAM.
                if ((age >= 110) || (age <= 3))
                {
                    throw new OverflowException();
                }

                // CONSOLE INPUT AND PARSING OF GENDER THAN CONVER IT INTO CORRESPONDING enum. ToLower() USED BECAUSE IN UserGender STRING VALUE ARE IN THE LOWER CASE.
                Console.Write("PLEASE, ENTER THE GENDER (0 — UNKNOWN, 10 — MALE, 11 — FEMALE): ");
                UserGender gender = (UserGender)Enum.Parse(typeof(UserGender), Console.ReadLine().ToLower());

                Console.WriteLine();

                #region
                // IF GENDER IS SOMETHING DIFFERENT FROM GENDER ENUMERATION, TERMINATE THE PROGRAM.
                // IF IsDefined() METHOD RETURN TRUE — THE PROPER GENDER SELECTED FROM UserGender ENUMERATION, AND DUE TO THE NEGATION OPERATOR THE PROGRAM AVOIDS THE CODE INSIDE if() CONSTRUCTION. ELSE TERMINATE THE PROGRAM.
                // https://learn.microsoft.com/en-us/dotnet/api/system.enum.isdefined?view=net-8.0
                #endregion
                if (!Enum.IsDefined(typeof(UserGender), gender))
                {
                    throw new FormatException();
                }

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
            catch (NullReferenceException nullException)
            {
                Console.WriteLine($"{nullException.Message}");
            }
            catch (ArgumentException argumentException)
            {
                Console.WriteLine($"{argumentException.Message}");
            }
            catch
            {
                Console.WriteLine("A CRITICAL ERROR APPEARED!!!");
            }
        }

        // THE METHOD DELETES ALL WHITESPACES.
        internal static string DeleteSpacesAfterBefore(string name)
        {
            name = Regex.Replace(name, @"\s+", string.Empty);
            return name;
        }

        internal static void ValidateName(string name)
        {
            // THE PROGRAM CHECKS INPUT FOR name ON EMPTY LINE, ONLY WHITE SPACES AND NULL.
            if (String.IsNullOrEmpty(name))
            {
                throw new FormatException();
            }

            // IF name IS TOO LONG, THEN THROW THE EXCEPTION.
            if (name.Length >= 64)
            {
                throw new FormatException();
            }

            // A VALIDATION WITH HELP OF REGULAR EXPRESSIONS.
            // JUST TO MAKE THE SOURCE CODE MORE READABLE, LOCALIZE REGEX IN THE BOOL VALUE.
            // 0 — MEANS NO OPTION IS SET.
            bool nameIsMatch = Regex.IsMatch(name, _patternNameRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(_timeoutRegexCheckup));

            if (nameIsMatch)
            {
                throw new FormatException();
            }
        }
    }
}