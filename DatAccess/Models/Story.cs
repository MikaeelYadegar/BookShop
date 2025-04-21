using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatAccess.Models
{
    public class Story
    {
        public int Id { get; set; }
        public byte [] MediaData { get; set; }
        public string MediaMimeType {  get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
