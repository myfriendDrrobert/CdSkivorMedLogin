using CdSkivorUppgift.Entities;

namespace CdSkivorUppgift.Data
{
    public class RecordRepo : IRecord
    {
        private readonly CdSkivorUppgiftContext _dbcontext;

        public RecordRepo(CdSkivorUppgiftContext dbcontext)
        {
            this._dbcontext = dbcontext;
        }
        public void Add(Record record)
        {
            _dbcontext.Records.Add(record);
            _dbcontext.SaveChanges();    
        }

        public void Delete(Record record)
        {
            _dbcontext.Records.Remove(record);
            _dbcontext.SaveChanges();
        }

        public IEnumerable<Record> GetAll()
        {
            return _dbcontext.Records.OrderBy(r => r.Id).ToList();
        }

        public List<string> GetSongTitles(int id) {

            var titlesToReturn = new List<string>();
            var songs=  _dbcontext.Songs.Where(s => s.RecordId.Equals(id));  
            
            foreach (var s in songs) {
                titlesToReturn.Add($"{s.Title} ({s.Length})");
            }
            return titlesToReturn;
        }

        public Record GetById(int id)
        {
            return _dbcontext.Records.FirstOrDefault(r => r.Id.Equals(id));
        }

        public void Update(Record record)
        {
            _dbcontext.Records.Update(record);
            _dbcontext.SaveChanges();
        }
    }
}
