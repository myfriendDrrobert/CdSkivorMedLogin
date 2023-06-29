using System.ComponentModel.DataAnnotations;
using CdSkivorUppgift.Data;

namespace CdSkivorUppgift.Entities
{
    public class Record 
    {
        public int Id { get; set; }

        public string ArtistName { get; set; }
        public string AlbumName { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        public string RecordCompany { get; set; }

        public virtual List<Song>? Songs { get; set; }
    }
}
