using Microsoft.AspNetCore.Mvc;
using SimplifiedSlotMachineV1.Application.Common;
using SimplifiedSlotMachineV1.Domain.Helpers;
using SimplifiedSlotMachineV1.Domain.Repositories;
using SimplifiedSlotMachineV1.Domain.Services.Interfaces;
using SimplifiedSlotMachineV1.Web.Dtos;
using SimplifiedSlotMachineV1.Web.Validations;

namespace SimplifiedSlotMachineV1.Web.Http;

[Route("api/v1/[controller]")]
[ApiController]
public class UsersController : BaseController
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService, IUserRepository userRepository) : base(userRepository)
    {
        _userService = userService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<UserReadDto>> GetAllUsers()
    {
        Console.WriteLine(ApplicationMessages.GETTING_ALL_USERS);

        var userReadDtos = _userService.GetAllUsers();

        return Ok(userReadDtos);
    }

    [HttpGet("{userId}", Name = "GetUserById")]
    public ActionResult<UserReadDto> GetUserById([FromRoute] UserIdValidation userIdValidation)
    {
        Console.WriteLine(ApplicationMessages.GETTING_USER);

        var userId = userIdValidation.UserId;

        if (EnsureValidUser(userId))
        {
            var userReadDto = _userService.GetUserById(userId);

            return Ok(userReadDto);
        }

        return BadRequest();
    }

    [HttpPost]
    public ActionResult<UserReadDto> CreateUser(UserCreateDto userCreateDto)
    {
        try
        {
            var userReadDto = _userService.CreateUser(userCreateDto);

            return CreatedAtRoute(
                nameof(GetUserById),
                new { Id = userReadDto.UserId },
                userReadDto
            );
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }

    [HttpGet("{userId}/deposit")]
    public ActionResult<double> GetUserDepositByUserId([FromRoute] UserIdValidation userIdValidation)
    {
        var userId = userIdValidation.UserId;

        if (EnsureValidUser(userId))
        {
            var deposit = _userService.GetUserDepositByUserId(userIdValidation.UserId);

            return Ok(Formatter.Format(deposit));
        }

        return BadRequest();
    }

    [HttpPost("{userId}/deposit/{deposit}")]
    public ActionResult UpdateUserDeposit(int userId, double deposit)
    {
        _userService.UpdateUserDeposit(userId, deposit);

        return NoContent();
    }
}