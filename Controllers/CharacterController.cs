using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dotnet6.Dtos.Characters;
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
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Get(){
            return Ok( await _character.GetAllCharacters());
        } 
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetSingle(int id){
            return Ok(await _character.GetCharacterById(id));
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> AddCharacter(AddCharacterDto newCharacter){
            return Ok(await _character.AddCharacter(newCharacter));
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> UpdateCharacter(UpdateCharacterDto updateCharacter){
            var response = await _character.UpdateCharacter(updateCharacter);
            if(response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> Delete(int id){
            var response = await _character.DeleteCharacter(id);
            if(response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}