using MusicShop.Data.Dto.OutComing.Song;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Data.Dto.OutComing.Singer
{
    public class SingerEager
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<SingleSongEager> SingleSongs { get; set; }
    }
}
