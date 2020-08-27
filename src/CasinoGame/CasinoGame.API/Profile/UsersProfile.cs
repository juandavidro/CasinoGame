using CasinoGame.API.CasinoGame.DataAccess.Entities;
using CasinoGame.DataAccess.Entities;
using CasinoGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasinoGame.API.Profile
{
    public class UsersProfile : AutoMapper.Profile
    {
        public UsersProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}")
                );
            CreateMap<UserForCreationDto, User>();
            CreateMap<Roulette, RouletteDto>();
            CreateMap<Bet, BetDto>();
            CreateMap<BetForCreation, Bet>();
            CreateMap<RouletteToUpdate, Roulette>();
        }
    }
}
