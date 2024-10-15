using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Data.Dto.InComing.UpdateDto.Song
{
    public class UpdateDtoForSingleSong :BaseDto
    {
        public string Category { get; set; }
        public int Price { get; set; }
    }
}
