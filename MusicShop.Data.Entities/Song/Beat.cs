using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Data.Entities.Song
{
    public class Beat :BaseModel
    {
        public string Name {  get; set; }

        public ICollection<SingleBeat> SingleBeats { get; set; }
    }
}
