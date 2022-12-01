using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dotnet6.Dtos.Characters;

namespace Dotnet6.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character>{
            new Character(),
            new Character { Id=1, Name = "Bayrak", }
        };
        private readonly IMapper _mapper;
        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var response = new ServiceResponse<List<GetCharacterDto>>();
            Character character = _mapper.Map<Character>(newCharacter);
            character.Id = characters.Max(c=>c.Id) + 1;
            characters.Add(character);
            response.Data = characters.Select(c=> _mapper.Map<GetCharacterDto>(c)).ToList();
            response.Message = "Added";
            return response;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            var response = new ServiceResponse<List<GetCharacterDto>>();
            try
            {
                var character = characters.First(c=>c.Id == id);
                characters.Remove(character);
                response.Data = characters.Select(c=> _mapper.Map<GetCharacterDto>(c)).ToList();
                response.Message = "Deleted";
            }
            catch (System.Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response; 
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            var response = new ServiceResponse<List<GetCharacterDto>>();
            response.Data = _mapper.Map<List<GetCharacterDto>>(characters);
            return response;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var response = new ServiceResponse<GetCharacterDto>();
            var character = characters.FirstOrDefault(c=>c.Id == id);
            response.Data = _mapper.Map<GetCharacterDto>(character);
            return response;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateCharacter)
        {
            var response = new ServiceResponse<GetCharacterDto>();
            try
            {
                var character = characters.FirstOrDefault(c=>c.Id == updateCharacter.Id);

                _mapper.Map(updateCharacter,character);
                // character.Name = updateCharacter.Name;
                // character.HitPoints = updateCharacter.HitPoints;
                // character.Strength = updateCharacter.Strength;
                // character.Defense = updateCharacter.Defense;
                // character.Intelligence = updateCharacter.Intelligence;
                // character.Class = updateCharacter.Class;

                response.Data = _mapper.Map<GetCharacterDto>(character);
                
            }
            catch (System.Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response; 
        }
    }
}