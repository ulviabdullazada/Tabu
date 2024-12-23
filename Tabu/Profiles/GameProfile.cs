using AutoMapper;
using Tabu.DTOs.Games;
using Tabu.Entities;

namespace Tabu.Profiles
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<GameCreateDto, Game>()
                .ForMember(g => g.Time, y => y.MapFrom(gcd => new TimeSpan(10000000 * gcd.Seconds)))
                .ForMember(x => x.BannedWordCount, y => y.MapFrom(z => (int)z.GameLevel));
        }
    }
}
