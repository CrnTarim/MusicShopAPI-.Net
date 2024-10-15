using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Data.Entities.Song
{
    public class SingleBeat:BaseModel
    {
        public string Label {  get; set; }

        public Guid SingleSongId { get; set; }
        public SingleSong SingleSong { get; set; }

        public Guid BeatId { get; set; }
        public Beat Beat { get; set; }
    }
}
