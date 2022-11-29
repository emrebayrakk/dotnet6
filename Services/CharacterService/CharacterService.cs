using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotnet6.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character>{
            new Character(),
            new Character { Id=1, Name = "Bayrak", }
        };
        public async Task<ServiceResponse<List<Character>>> AddCharacter(Character newCharacter)
        {
            var response = new ServiceResponse<List<Character>>();
            characters.Add(newCharacter);
            response.Data = characters;
            response.Message = "Added";
            return response;
        }

        public async Task<ServiceResponse<List<Character>>> GetAllCharacters()
        {
            var response = new ServiceResponse<List<Character>>();
            response.Data = characters;
            return response;
        }

        public async Task<ServiceResponse<Character>> GetCharacterById(int id)
        {
            var response = new ServiceResponse<Character>();
            var character = characters.FirstOrDefault(c=>c.Id == id);
            response.Data = character;
            return response;
        }
    }
}