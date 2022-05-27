using Microsoft.AspNetCore.Mvc;
using SimplifiedSlotMachineV1.Application.Common;
using SimplifiedSlotMachineV1.Domain.Repositories;
using SimplifiedSlotMachineV1.Domain.Services.Interfaces;
using SimplifiedSlotMachineV1.Web.Dtos;
using SimplifiedSlotMachineV1.Web.Validations;

namespace SimplifiedSlotMachineV1.Web.Http;

[Route("api/v1/[controller]")]
[ApiController]
public class SpinSlotMachineController : BaseController
{
    private readonly ISpinSlotMachineService _rollService;

    public SpinSlotMachineController(ISpinSlotMachineService rollService, IUserRepository userRepository) : base(userRepository)
    {
        _rollService = rollService;
    }

    [HttpGet("{userId}")]
    public ActionResult<SlotMachineResultReadDto> SpinSlotMachine([FromRoute] UserIdValidation userIdValidation)
    {
        var userId = userIdValidation.UserId;

        if (EnsureValidUser(userId))
        {
            return Ok(
            _rollService.Roll(userIdValidation.UserId)
            );
        }

        return NotFound(ApplicationMessages.USER_NOT_FOUND);
    }
}