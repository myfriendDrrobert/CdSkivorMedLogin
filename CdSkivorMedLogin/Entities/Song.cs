using CdSkivorUppgift.Data;

namespace CdSkivorUppgift.Entities
{
    public class Song 
    {
        public int Id { get; set; }

        public int RecordId { get; set; }

        public string Title { get; set; }
        public TimeSpan Length { get; set; }

        public string Author { get; set; }

        public Record? Record { get; set; }

        
    }
}
