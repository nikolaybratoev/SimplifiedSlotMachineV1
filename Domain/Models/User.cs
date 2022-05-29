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
    public decimal Deposit { get; set; }

    public decimal StakeAmount { get; set; }
}