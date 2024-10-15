using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Data.Dto.InComing.CreationDto.Song
{
    public class CreationDtoForSingleSong :BaseDto
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }
        public Guid SingerId { get; set; }

    }
}
