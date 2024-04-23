using System.ComponentModel.DataAnnotations;


namespace DataSaving.Models;

public class AddContactViewModel
{
    [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$", ErrorMessage = "Please enter a valid first name with only letters and spaces, starting with a capital letter.")]
    [Required(ErrorMessage = "Please enter a first name.")]
    public string? FirstName { get; set; }

    [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
    [Required(ErrorMessage = "Please enter a last name")]
    public string? LastName { get; set; }
    

    [Required(ErrorMessage = "Please enter a first email")]
    public string? Email { get; set; }

    [StringLength(9)]
    [Required(ErrorMessage = "Please enter a first phone")]
    public string? Phone { get; set; }
}
