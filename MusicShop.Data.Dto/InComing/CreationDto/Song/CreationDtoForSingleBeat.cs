using MusicShop.Data.Entities.Song;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Data.Dto.InComing.CreationDto.Song
{
    public class CreationDtoForSingleBeat:BaseDto
    {
        public string Label { get; set; }

        public Guid SingleSongId { get; set; }

        public Guid BeatId { get; set; }
    }
}
