using Microsoft.AspNetCore.Mvc;
using SimplifiedSlotMachineV1.Application.Common;
using SimplifiedSlotMachineV1.Domain.Repositories;
using SimplifiedSlotMachineV1.Domain.Services.Interfaces;
using SimplifiedSlotMachineV1.Web.Dtos;
using SimplifiedSlotMachineV1.Web.Validations;

namespace SimplifiedSlotMachineV1.Web.Http;

[Route("api/v1/slotmachine")]
[ApiController]
public class StakeAmountController : BaseController
{
    private readonly IStakeAmountService _stakeAmountService;

    public StakeAmountController(IStakeAmountService stakeAmountService, IUserRepository userRepository) : base(userRepository)
    {
        _stakeAmountService = stakeAmountService;
    }

    [HttpGet("{userId}")]
    public ActionResult<StakeAmountReadDto> GetUserStakeAmount([FromRoute] UserIdValidation userIdValidation)
    {
        var userId = userIdValidation.UserId;

        if (EnsureValidUser(userId))
        {
            Console.WriteLine(ApplicationMessages.GETTING_STAKE_AMOUNT);

            var stakeAmountReadDto = _stakeAmountService.GetUserStakeAmountByUserId(userId);

            if (stakeAmountReadDto.StakeAmount != 0)
            {
                return Ok(stakeAmountReadDto);
            }

            return BadRequest(ApplicationMessages.ENTER_STAKE_AMOUNT);
        }

        return NotFound(ApplicationMessages.USER_NOT_FOUND);
    }

    [HttpPost("{userId}/stakeamount/{amount}")]
    public ActionResult<StakeAmountReadDto> EnterUserStakeAmountByUserId([FromRoute] StakeAmountValidation stakeAmountValidation)
    {
        var userId = stakeAmountValidation.UserId;
        var stakeAmount = stakeAmountValidation.Amount;

        if (EnsureValidUser(userId))
        {
            Console.WriteLine(ApplicationMessages.ENTERING_STAKE_AMOUNT);

            var stakeAmountReadDto = _stakeAmountService.EnterUserStakeAmountByUserId(userId, stakeAmount);

            if (stakeAmountReadDto != null)
            {
                return Ok(stakeAmountReadDto);
            }

            return BadRequest(ApplicationMessages.DEPOSIT_NOT_ENOUGH);
        }

        return NotFound(ApplicationMessages.USER_NOT_FOUND);
    }
}