using Microsoft.AspNetCore.Mvc;
using SimplifiedSlotMachineV1.Domain.Repositories;

namespace SimplifiedSlotMachineV1.Web.Http;

public class BaseController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public BaseController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    protected bool EnsureValidUser(int userId)
    {
        return _userRepository.UserExists(userId);
    }
}