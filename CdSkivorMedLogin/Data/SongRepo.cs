using CdSkivorUppgift.Entities;

namespace CdSkivorUppgift.Data
{
    public class SongRepo : ISong
    {
        private readonly CdSkivorUppgiftContext _dbcontext;

        public SongRepo(CdSkivorUppgiftContext dbcontext)
        {
            this._dbcontext = dbcontext;
        }
        public void Add(Song song)
        {
            _dbcontext.Songs.Add(song);
            _dbcontext.SaveChanges();
        }

        public void Delete(Song song)
        {
            _dbcontext.Songs.Remove(song);
            _dbcontext.SaveChanges();
        }

        public IEnumerable<Song> GetAll()
        {
            return _dbcontext.Songs.OrderBy(s => s.Id).ToList();
        }

        public IEnumerable<Record> GetAllRecords()
        {
            return _dbcontext.Records.OrderBy(r => r.Id).ToList();
        }

        public Song GetById(int id)
        {
            return _dbcontext.Songs.FirstOrDefault(s => s.Id.Equals(id));
        }

        public void Update(Song song)
        {
            _dbcontext.Songs.Update(song);
            _dbcontext.SaveChanges();
        }
    }
}
