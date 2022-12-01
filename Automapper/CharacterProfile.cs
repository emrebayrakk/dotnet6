using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dotnet6.Dtos.Characters;

namespace Dotnet6.Automapper
{
    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            CreateMap<AddCharacterDto,Character>();
            CreateMap<Character,GetCharacterDto>();
            CreateMap<UpdateCharacterDto,Character>();
        }
    }
}