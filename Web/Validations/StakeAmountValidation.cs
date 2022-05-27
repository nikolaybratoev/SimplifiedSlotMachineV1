using System.ComponentModel.DataAnnotations;

namespace SimplifiedSlotMachineV1.Web.Validations;

public class StakeAmountValidation
{
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Invalid format")]
    public int UserId { get; set; }

    [Required]
    [Range(1, double.MaxValue, ErrorMessage = "Invalid format")]
    public double Amount { get; set; }
}