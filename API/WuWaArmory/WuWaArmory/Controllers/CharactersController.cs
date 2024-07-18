using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WuWaArmory.Data;

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



    }
}
