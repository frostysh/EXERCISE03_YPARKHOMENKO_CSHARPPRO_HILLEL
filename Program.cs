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
                // VARIABLES FOR LOOP OF CONSOLE INPUT.
                int inputCount = 5;
                bool isValidAge = false;
                bool isValidFirstName = false;
                bool isValidLastName = false;
                bool isValidGender = false;
                string firstNameLoop = string.Empty;
                string lastNameLoop = string.Empty;
                UserGender genderLoop = UserGender.unknown;
                bool isValidationSuccess = false; // TO MAKE LOGIC MORE READABLE.

                // VARIABLE WHICH ARE ARGUMENTS FOR A CONSTRUCTOR.
                byte age = 0;
                UserGender gender = UserGender.unknown;
                string firstName = string.Empty;
                string lastName = string.Empty;

                // INPUT AND VALIDATION OF firstName AND lastName

                do
                {
                    if (isValidFirstName == false)
                    {
                        Console.Write($"PLEASE, ENTER THE FIRST NAME ({inputCount} — ATTEMPTS LEFT): ");
                        firstNameLoop = Console.ReadLine();
                        Console.WriteLine();

                        isValidFirstName = ValidateName(firstNameLoop);
                        
                        // IF INPUT IS NOT VALID TO START LOOP OVER.
                        if (isValidFirstName == false)
                        {
                            inputCount = inputCount - 1;
                            continue;
                        }
                    }
                    
                    // TO NOT ASSIGN EVERY TIME WE SHOULD CHECK IF TWO VALUES EQUALS.
                    if ((isValidFirstName == true) && (firstName != firstNameLoop))
                    {
                        firstName = firstNameLoop;
                    }

                    if (isValidLastName == false)
                    {
                        Console.Write($"PLEASE, ENTER THE LAST NAME ({inputCount} — ATTEMPTS LEFT): ");
                        lastNameLoop = Console.ReadLine();
                        Console.WriteLine();

                        isValidLastName = ValidateName(lastNameLoop);

                        if (isValidLastName == false)
                        {
                            inputCount = inputCount - 1;
                            continue;
                        }
                    }

                    if ((isValidLastName == true) && (lastName != lastNameLoop))
                    {
                        lastName = lastNameLoop;
                    }

                    // VALIDATION OF AGE.
                    if (isValidAge == false)
                    {
                        // CONSOLE INPUT OF AGE.
                        Console.Write($"PLEASE, ENTER THE AGE ({inputCount} — ATTEMPTS LEFT): ");
                        isValidAge = byte.TryParse(Console.ReadLine(), out age);
                        Console.WriteLine();

                        // IF AGE IS IN THE BORDERS.
                        if ((isValidAge) && ((age <= 110) && (age >= 3)))
                        {
                            isValidAge = true;
                        }
                        else
                        {
                            isValidAge = false;
                            inputCount = inputCount - 1;
                            continue;
                        }
                    }

                    // CONSOLE INPUT AND PARSING OF GENDER THAN CONVER IT INTO CORRESPONDING enum. ToLower() USED BECAUSE IN UserGender STRING VALUE ARE IN THE LOWER CASE.
                    if (isValidGender == false)
                    {
                        Console.Write($"PLEASE, ENTER THE GENDER (0 — UNKNOWN, 10 — MALE, 11 — FEMALE) ({inputCount} — ATTEMPTS LEFT): ");
                        try
                        {
                            genderLoop = (UserGender)Enum.Parse(typeof(UserGender), Console.ReadLine().ToLower());
                        }
                        catch (ArgumentException argumentException)
                        {
                            Console.WriteLine(argumentException.Message);
                            inputCount = inputCount - 1;
                            continue;
                        }
                        catch
                        {
                            Console.WriteLine("CHOOSE THE CORRECT VARIANT OF GENDER!!!");
                            inputCount = inputCount - 1;
                            continue;
                        }

                        Console.WriteLine();

                        #region
                        // IF GENDER IS SOMETHING DIFFERENT FROM GENDER ENUMERATION, TERMINATE THE PROGRAM.
                        // IF IsDefined() METHOD RETURN TRUE — THE PROPER GENDER SELECTED FROM UserGender ENUMERATION, AND DUE TO THE NEGATION OPERATOR THE PROGRAM AVOIDS THE CODE INSIDE if() CONSTRUCTION. ELSE TERMINATE THE PROGRAM.
                        // https://learn.microsoft.com/en-us/dotnet/api/system.enum.isdefined?view=net-8.0
                        #endregion
                        isValidGender = Enum.IsDefined(typeof(UserGender), genderLoop);

                        if (isValidGender == false)
                        {
                            inputCount = inputCount - 1;
                            continue;
                        }
                    }

                    if ((isValidGender == true) && (gender != genderLoop))
                    {
                        gender = genderLoop;
                    }

                    // EVALUEATE INDICATOR VARIABLE.
                    isValidationSuccess = (isValidAge && isValidFirstName && isValidLastName && isValidGender);

                    // DECREMENT OF THE LOOP INDEX.
                    inputCount = inputCount - 1;
                }
                while ((inputCount > 0) || (isValidationSuccess == false));

                // IF VALIDATION OF THE USER INPUT WAS SUCCESSFUL, INVOKE THE CONSTRUCTOR.
                if (isValidationSuccess)
                {
                    // WHITESPACES ERASING.
                    firstName = DeleteSpacesAfterBefore(firstName);
                    lastName = DeleteSpacesAfterBefore(lastName);

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
                else
                {
                    Console.WriteLine("AN ERROR OCCURED!!!");
                    return;
                }

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

        internal static bool ValidateName(string name)
        {
            // A VALIDATION WITH HELP OF REGULAR EXPRESSIONS.
            // JUST TO MAKE THE SOURCE CODE MORE READABLE, LOCALIZE REGEX IN THE BOOL VALUE.
            // 0 — MEANS NO OPTION IS SET.
            bool nameIsMatch = Regex.IsMatch(name, _patternNameRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(_timeoutRegexCheckup));

            // THE PROGRAM CHECKS INPUT FOR name ON EMPTY LINE, ONLY WHITE SPACES AND NULL. AND IT CHECKS THE LENGTH. AND IT PERFORMS REGULAR EXPRESSION CHECKS.
            if ((String.IsNullOrEmpty(name)) || (name.Length >= 64) || nameIsMatch)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}