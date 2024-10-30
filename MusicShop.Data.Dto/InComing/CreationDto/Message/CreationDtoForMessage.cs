using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Data.Dto.InComing.CreationDto.Message
{
    public class CreationDtoForMessage
    {
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public string Content { get; set; }
    }
}
