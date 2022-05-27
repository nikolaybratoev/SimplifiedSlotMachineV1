using System.ComponentModel.DataAnnotations;

namespace SimplifiedSlotMachineV1.Web.Dtos;

public class UserCreateDto
{
    [Required]
    public string Name { get; set; }

    [Required]
    public double Deposit { get; set; }
}