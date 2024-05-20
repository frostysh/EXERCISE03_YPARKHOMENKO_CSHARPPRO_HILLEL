using System.Diagnostics.CodeAnalysis;      // CONNECTION TO SPECIAL CLASS TO USE ATTRIBUTES FOR THE CONSTRUCTOR.

// HILLEL, C# PRO COURSE, TEACHER: MARIIA DZIVINSKA
// HOMEWORK 03: "Console program with objects"
// STUDENT: PARKHOMENKO YAROSLAV
// DATE: 06-MAY-2024

namespace DZ_03
{
    internal class User
    {
        // PROPERTIES

        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required byte Age { get; init; }
        public required UserGender Gender { get; set; }

        // METHODS

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
        }

        // CONSTRUCTOR WICH SETUPS Age PROPERTY WITH ATTRIBUTE TO FORCE REQUIRED MEMBERS.
        [SetsRequiredMembers]

        public User(byte age)
        {
            this.Age = age;
        }
    }
}