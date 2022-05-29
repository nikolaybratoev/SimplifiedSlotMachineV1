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
    private readonly ISpinSlotMachineService _spinSlotMachineService;

    public SpinSlotMachineController(ISpinSlotMachineService spinSlotMachineService, IUserRepository userRepository) : base(userRepository)
    {
        _spinSlotMachineService = spinSlotMachineService;
    }

    [HttpGet("{userId}")]
    public ActionResult<SlotMachineResultReadDto> SpinSlotMachine([FromRoute] UserIdValidation userIdValidation)
    {
        var userId = userIdValidation.UserId;

        if (EnsureValidUser(userId))
        {
            var result = _spinSlotMachineService.Spin(userIdValidation.UserId);

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest(ApplicationMessages.ENTER_STAKE_AMOUNT);
        }

        return NotFound(ApplicationMessages.USER_NOT_FOUND);
    }
}