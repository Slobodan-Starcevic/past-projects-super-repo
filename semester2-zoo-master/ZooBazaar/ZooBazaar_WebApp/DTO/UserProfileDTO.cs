using System.ComponentModel.DataAnnotations;

namespace WebApp.DTO
{
    public class UserProfileDTO
    {
        public UserProfileDTO()
        {
        }

        [Required(ErrorMessage = "First name missing")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name missing")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Personal mail missing")]
        public string PersonalEmail { get; set; }

        [Required(ErrorMessage = "Gender missing")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Adress missing")]
        [RegularExpression(@"^[1-9][0-9]{3}\s*(?!sa|sd|ss)[a-zA-Z]{2}$", ErrorMessage = "Please fill in a Postal code in the format 1234 AB")]
        public string PostalCode { get; set; }

        //not allowed to change
        public string SSN { get; set; }

        //not allowed to change
        public string IBAN { get; set; }

        //not allowed to change
        public string BirthDate { get; set; }

        //not allowed to change
        public string WorkEmail { get; set; }
    }
}
