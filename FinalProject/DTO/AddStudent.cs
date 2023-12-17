using System.ComponentModel.DataAnnotations;

namespace FinalProject.DTO
{
    public class AddStudent
    {
        public string Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string? SecondName { get; set; }
        public string? thirdName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string major { get; set; }
        public string? number_universtity { get; set; }
        public int? Age { get; set; }
       
        public int UniversityId { get; set; }

        public lookupUniversity University { get; set; }
        public string? National_number { get; set; }
    }

    public class lookupUniversity
    {
        public int Id { get; set; }
        public string name { get; set; }
    } 
}
