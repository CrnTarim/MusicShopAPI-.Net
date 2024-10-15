using MusicShop.Data.Entities.SingerInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Data.Entities.Song
{
    public class SingleSong :BaseModel
    {
        public string Name { get; set; }

        public string Category { get; set; }

        public int Price { get; set; }

        public Guid SingerId { get; set; }  

        public Singer Singer { get; set; } 
        
        public ICollection<SingleBeat> SingleBeats { get; set; }

    }
}
