using System.Diagnostics.CodeAnalysis;      // CONNECTION TO SPECIAL CLASS TO USE ATTRIBUTES FOR THE CONSTRUCTOR.

namespace DZ_03
{
    internal class User
    {
        // PROPERTIES

        public string FirstName { get; set; }     // INITIAL VALUE IS "NO_NAME".
        public string LastName { get; set; }
        // USING OF KEYWORD init TO INITIALIZE Age PROPERTY ONLY ONCE, AND THEN MAKE IT immutable.
        public byte Age { get; init; }
        // THE CREATION OF Gender PROPERTY WHICH CORRESPONDS TO enum UserGender TYPE.
        public UserGender Gender { get; set; }      // THE DEFAULT VALUE IS Unknown = 0.

        // METHODS

        // THE METHOD ToString() FROM System.Object OVERRIDED TO MAKE PROPER OUTPUT FOR INSTANCES OF User.
        public override string ToString()
        {
            // THE CHECK TO MAKE A PROPER OUT PUT FOR THE UNDERAGES.
            if (this.Age <= 10)
            {
                return $"Hi, my name is {this.FirstName} and last name {this.LastName}. I am a baby. I am {this.Gender}.";
            }
            else
            {
                return $"Hi, my name is {this.FirstName} and last name {this.LastName}. I am {this.Age} years old. I am {this.Gender}.";
            }
        }

        // CONSTRUCTORS

        // DEFAULT CONSTRUCTOR WITHOUT PARAMETERS.
        public User()
        {
            Console.WriteLine("THE DEFAULT CONSTRUCTOR OF User INITIALIZED!");

            // DEFAULT VALUES OF PROPERTIES.
            this.FirstName = "NO_NAME";
            this.LastName = "NO_NAME";
        }

        // CONSTRUCTOR WICH SETUPS Age PROPERTY.
        [SetsRequiredMembers]    // PARAMETER THAT USED CONFIGURE CONSTRUCTOR TO SHOW THAT SETUP AGE WITH DEFAULT VALUE WILL BE DONE IN ANY CASE, AND THAT BECAUSE CALLER IS NOT FORCED TO ASSIGN VALUE ON COMPILATION STAGE... :S AT LEAST AS I HAVE UNDERSTAND.
        public User(byte age)
        {
            // DEFAULT VALUES OF PROPERTIES.
            this.FirstName = "NO_NAME";
            this.LastName = "NO_NAME";

            this.Age = age;     // ASSIGN PROPERTY Age VIA CONSTRUCTOR METHOD.
        }
    }

    // THE enum TYPE IS INITIALIZED, IT CONNECTS TO THE User CLASS.
    enum UserGender : byte
    {
        Unknown = 0,
        Male = 10,
        Female = 11
    }
}