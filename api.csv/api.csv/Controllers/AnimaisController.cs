using api.csv.DataBase;
using api.csv.DataBase.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace api.csv.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimaisController : ControllerBase
    {

        private readonly dbContext _dbContext;

        public AnimaisController(dbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        [HttpGet]
        public ActionResult<List<Animal>> GetAll()
        {
            return Ok(_dbContext.Animals);
        }

        [HttpGet("{id}")]
        public ActionResult<Animal> GetById(int id)
        {
            try
            {
                Animal animal =
                    _dbContext
                    .Animals.Find(a => a.Id == id);

                if (animal == null)
                    return NotFound(); //404

                return Ok(animal); //200
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message); //400
            }
        }

        [HttpDelete("{id}")]

        public ActionResult<Animal>Delete(int id)
        {

           try
           { 
                Animal animal =
                    _dbContext
                    .Animals.Find(a => a.Id == id);

                if (animal == null)
                    return NotFound(); //404

                _dbContext.Animals.Remove(animal);
                return NoContent();
           }
           catch (System.Exception e)
           {
                return BadRequest(e.Message); //400
           }
            

        }
    }
}
