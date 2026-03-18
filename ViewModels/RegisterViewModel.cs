using System.ComponentModel.DataAnnotations;

namespace UrbanPalate.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Please Enter Your Name :")]
        public string Name { get; set; }
        [EmailAddress(ErrorMessage = "Please Enter Correct Email :")]
        [Key]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Password :")]
        [StringLength(40, MinimumLength = 8, ErrorMessage = "The {0} must be at {2} and at max {1} charecter.")]
        [Compare("ConfirmPassword", ErrorMessage = "Password does not match.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please Enter Confirm Password :")]
        [DataType(DataType.Password)]
        [Display(Name = " Confirm Password")]
        public string ConfirmPassword{ get; set;}
    }
}
