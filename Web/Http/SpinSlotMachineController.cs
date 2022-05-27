using Microsoft.AspNetCore.Mvc;
using SimplifiedSlotMachineV1.Domain.Services.Interfaces;
using SimplifiedSlotMachineV1.Web.Dtos;
using SimplifiedSlotMachineV1.Web.Validations;

namespace SimplifiedSlotMachineV1.Web.Http;

[Route("api/v1/[controller]")]
[ApiController]
public class SpinSlotMachineController : ControllerBase
{
    private readonly ISpinSlotMachineService _rollService;

    public SpinSlotMachineController(ISpinSlotMachineService rollService)
    {
        _rollService = rollService;
    }

    [HttpGet("{userId}")]
    public ActionResult<SlotMachineResultReadDto> SpinSlotMachine([FromRoute] UserIdValidation userIdValidation)
    {
        return Ok(
            _rollService.Roll(userIdValidation.UserId)
        );
    }
}