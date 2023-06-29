using CdSkivorUppgift.Data;
using CdSkivorUppgift.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CdSkivorApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class SongController : ControllerBase
    {
        private readonly ISong _songRepo;

        public SongController(ISong repo)
        {
            _songRepo = repo;
        }
        // GET: api/<SongController>
        [HttpGet]
        public IEnumerable<Song> Get()
        {
            return _songRepo.GetAll().ToList();
        }

        // GET api/<SongController>/5
        [HttpGet("{id}")]
        public Song Get(int id)
        {
            return _songRepo.GetById(id);
        }

        // POST api/<SongController>
        [HttpPost]
        public void Post([FromBody] Song song)
        {
            _songRepo.Add(song);
        }

        // PUT api/<SongController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Song song)
        {
            _songRepo.Update(song);
        }

        // DELETE api/<SongController>/5
        [HttpDelete("{id}")]
        public void Delete( int id)
        {
            var songToDelete = _songRepo.GetById(id);
            _songRepo.Delete(songToDelete);
        }
    }
}
