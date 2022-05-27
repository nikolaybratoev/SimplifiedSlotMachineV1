using Microsoft.AspNetCore.Mvc;
using SimplifiedSlotMachineV1.Application.Common;
using SimplifiedSlotMachineV1.Domain.Services.Interfaces;
using SimplifiedSlotMachineV1.Web.Dtos;
using SimplifiedSlotMachineV1.Web.Validations;

namespace SimplifiedSlotMachineV1.Web.Http;

[Route("api/v1/slotmachine")]
[ApiController]
public class StakeAmountController : ControllerBase
{
    private readonly IStakeAmountService _stakeService;

    public StakeAmountController(IStakeAmountService stakeService)
    {
        _stakeService = stakeService;
    }

    [HttpGet("{userId}")]
    public ActionResult<StakeAmountReadDto> GetUserStakeAmount([FromRoute] UserIdValidation userIdValidation)
    {
        Console.WriteLine(ApplicationMessages.GETTING_STAKE_AMOUNT);

        var stakeAmountReadDto = _stakeService.GetUserStakeAmountByUserId(userIdValidation.UserId);

        if (stakeAmountReadDto.StakeAmount != 0)
        {
            return Ok(stakeAmountReadDto);
        }

        return BadRequest(ApplicationMessages.ENTER_STAKE_AMOUNT);
    }

    [HttpPost("{userId}/stakeamount/{amount}")]
    public ActionResult<StakeAmountReadDto> EnterUserStakeAmountByUserId([FromRoute] StakeAmountValidation stakeAmountValidation)
    {
        Console.WriteLine(ApplicationMessages.ENTERING_STAKE_AMOUNT);

        var userId = stakeAmountValidation.UserId;
        var stakeAmount = stakeAmountValidation.Amount;

        var stakeAmountReadDto = _stakeService.EnterUserStakeAmountByUserId(userId, stakeAmount);

        if (stakeAmountReadDto != null)
        {
            return Ok(stakeAmountReadDto);
        }

        return BadRequest(ApplicationMessages.DEPOSIT_NOT_ENOUGH);
    }
}