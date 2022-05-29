using AutoMapper;
using SimplifiedSlotMachineV1.Domain.Models;
using SimplifiedSlotMachineV1.Web.Dtos;

namespace SimplifiedSlotMachineV1.Infrastructure.Profiles;

public class UsersProfile : Profile
{
    public UsersProfile()
    {
        CreateMap<User, UserReadDto>();
        CreateMap<User, StakeAmountReadDto>();
    }
}