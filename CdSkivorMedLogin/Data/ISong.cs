using CdSkivorUppgift.Entities;

namespace CdSkivorUppgift.Data
{
    public interface ISong
    {
        Song GetById(int id);

        IEnumerable<Song> GetAll();

        IEnumerable<Record> GetAllRecords();

        void Add(Song song);

        void Update(Song song);

        void Delete(Song song);
    }
}
