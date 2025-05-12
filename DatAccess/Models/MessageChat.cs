using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatAccess.Models
{
    public class MessageChat
    {
        public int Id { get; set; }
        public string SenderId { get; set; }
        public string ReciverId { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }

        public bool IsEdited {  get; set; }=false;
        public bool IsDeleted { get; set; } =false;
    }
}
