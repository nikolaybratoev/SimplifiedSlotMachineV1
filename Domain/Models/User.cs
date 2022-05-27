using System.ComponentModel.DataAnnotations;

namespace SimplifiedSlotMachineV1.Domain.Models;

public class User
{
    [Key]
    [Required]
    public int UserId { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public double Deposit { get; set; }

    public double StakeAmount { get; set; }
}