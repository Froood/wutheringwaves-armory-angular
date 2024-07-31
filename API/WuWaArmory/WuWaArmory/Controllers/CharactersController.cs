using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WuWaArmory.Data;
using WuWaArmory.Models;

namespace WuWaArmory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly WuWaDbContext dbContext;

        public CharactersController(WuWaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        public IActionResult GetAllCharacters()
        {
           var characters = dbContext.Characters.ToList();

           return Ok(characters);
        }

        [HttpGet]
        [Route("GetCharacterBy{id:guid}")]
        public async Task<IActionResult> GetCharacterById(Guid id)
        {
            var character = await dbContext.Characters.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (character == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(character);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCharacter(AddCharacterDto addCharacterDto)
        {

            var characterEntity = new Character() { 
                Name = addCharacterDto.Name,
                Age = addCharacterDto.Age,
                Description = addCharacterDto.Description,
                Rating = addCharacterDto.Rating,    
                Region = addCharacterDto.Region,    
            };

            await dbContext.Characters.AddAsync(characterEntity);
            await dbContext.SaveChangesAsync();
            return Ok(characterEntity);
        }

        [HttpPost]
        [Route("UpdateCharacterBy{id:guid}")]
        public async Task<IActionResult> UpdateCharacter(Guid id, UpdateCharacterDto updateCharacterDto)
        {
            var character = await dbContext.Characters.Where(c => c.Id == id).FirstOrDefaultAsync();

            if (character == null)
            {
                return NotFound();
            }
            
            character.Name = updateCharacterDto.Name;
            character.Description = updateCharacterDto.Description;
            character.Rating = updateCharacterDto.Rating;
            character.Region = updateCharacterDto.Region;   
            character.Age = updateCharacterDto.Age; 

            await dbContext.SaveChangesAsync();
            return Ok(character);
        }

        [HttpPost]
        [Route("DeleteCharacterBy{id:guid}")]
        public async Task<IActionResult> DeleteCharacterById(Guid id)
        {
           var character = await dbContext.Characters.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (character == null)
            {
                return NotFound();
            }
            dbContext.Characters.Remove(character);
            await dbContext.SaveChangesAsync();
            return Ok();
        }




    }
}
