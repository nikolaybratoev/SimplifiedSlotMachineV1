using System.ComponentModel.DataAnnotations;

namespace SimplifiedSlotMachineV1.Web.Validations;

public class UserIdValidation
{
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Invalid format")]
    public int UserId { get; set; }
}