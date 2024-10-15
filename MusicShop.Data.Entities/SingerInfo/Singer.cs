using MusicShop.Data.Entities.Song;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Data.Entities.SingerInfo
{
    public class Singer :BaseModel
    {
        public string Name {  get; set; }

        public ICollection<SingleSong> SingleSongs { get; set; }

    }
}
