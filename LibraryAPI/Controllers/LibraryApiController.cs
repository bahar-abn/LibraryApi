using LibraryAPI.Data;
using LibraryAPI.DTO;
using LibraryAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace LibraryAPI.Controllers
{
    [Route("api/LibraryApi")]
    [ApiController]
    public class LibraryApiController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public LibraryApiController(ApplicationDbContext db) {  _db = db; }

        [HttpGet]
        [ProducesResponseType(200)]
      
        public ActionResult<IEnumerable<LibraryDTO>> GetLibraries()
        {
            return Ok(_db.libraries.ToList());
        }

        [HttpGet("id",Name ="GetLibrary")]
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]

        public ActionResult<LibraryDTO> GetLibrary(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var library = _db.libraries.FirstOrDefault(u => u.Id == id);
            if (library == null)
            {
                return NotFound();
            }
            return Ok(library);
        }
        
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        [ProducesResponseType(404)]
        public ActionResult<LibraryDTO> CreatLibrary([FromBody]LibraryDTO libraryDTO) 
        { 
            if(_db.libraries.FirstOrDefault(u=>u.Name.ToLower() == libraryDTO.Name.ToLower()) != null) 
            {
                ModelState.AddModelError("", "The book already Exists!");
                return BadRequest(ModelState);
            }
            if (libraryDTO == null)
            {
                return BadRequest();
            }
            if (libraryDTO.Id>0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            library model = new()
            {
                Id = 2,
                Name = "Your word is your wand",
                Author = "Florence Scovel Shinn",
                Amount = 15
            };
            _db.libraries.Add(model);
            _db.SaveChanges();
           

            return CreatedAtRoute("GetLibrary",new {id = libraryDTO.Id}, libraryDTO);
        }

        [HttpDelete("id",Name = "DeletLibrary")]
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        [ProducesResponseType(404)]
        public IActionResult DeleteLibrary(int id) 
        {
            if(id==0)
            {
                return BadRequest();
            }
            var library = _db.libraries.FirstOrDefault(u=>u.Id==id);
            if (library == null)
            {
                return NotFound();
            }
           _db.libraries.Remove(library);
            _db.SaveChanges();
            return NoContent();
        }

        [HttpPut("id", Name = "UpdateLibrary")]

        public IActionResult UpdateLibrary(int id, [FromBody]LibraryDTO libraryDTO) 
        { 
            if (libraryDTO==null||id != libraryDTO.Id)
            {
                return BadRequest();
            }
            //var library = Library.librarylist.FirstOrDefault(u => u.Id == id);
            //library.Name = libraryDTO.Name;
            //library.Author = libraryDTO.Author;
            //library.Amount = libraryDTO.Amount;
            library model = new()
            {
                Id = 2,
                Name = "Your word is your wand",
                Author = "Florence Scovel Shinn",
                Amount = 15
            };
            _db.libraries.Add(model);
            _db.SaveChanges();

            return NoContent();
        }
    }
}
