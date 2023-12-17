using FinalProject.Data.Entites;
using Microsoft.AspNetCore.Identity;

namespace FinalProject.Data.Entites
{
    public class Person: IdentityUser
    {
        public string FirstName { get; set; }
        public string? SecondName { get; set; }
        public string? thirdName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
        public string? National_number { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
