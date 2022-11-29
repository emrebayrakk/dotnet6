using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dotnet6.Services.CharacterService;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet6.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _character;
        public CharacterController(ICharacterService character)
        {
            _character = character;
        }
        
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<Character>>>> Get(){
            return Ok( await _character.GetAllCharacters());
        } 
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<ServiceResponse<Character>>> GetSingle(int id){
            return Ok(await _character.GetCharacterById(id));
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Character>>>> AddCharacter(Character newCharacter){
            return Ok(await _character.AddCharacter(newCharacter));
        }
    }
}