using CdSkivorUppgift.Data;
using CdSkivorUppgift.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CdSkivorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RecordController : ControllerBase
    {



        private readonly IRecord _recordRepo;

        public RecordController(IRecord repo)
        {
            _recordRepo = repo;

        }
            // GET: api/<RecordController>
        [HttpGet]

        public IEnumerable<Record> Get()
        {
           return _recordRepo.GetAll().ToList();
        }

            // GET api/<RecordController>/5
            [HttpGet("{id}")]
        public Record Get(int id)
        {
            return _recordRepo.GetById(id);
        }

        [HttpGet("{id}/{getTitles}")]
        public List<string> Get(int id, string getTitles)
        {
            
            return _recordRepo.GetSongTitles(id); 

            
            
        }

        // POST api/<RecordController>
        [HttpPost]
        public void Post([FromBody] Record record)
        {
            _recordRepo.Add(record);
        }

        // PUT api/<RecordController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Record record)
        {
            _recordRepo.Update(record);
        }

        // DELETE api/<RecordController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var recordToDelete = _recordRepo.GetById(id);
            _recordRepo.Delete(recordToDelete);
        }
    }
}
