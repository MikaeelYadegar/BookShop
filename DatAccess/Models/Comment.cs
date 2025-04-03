using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DatAccess.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="لطفا نام خود را وارد نمایید")]
        public string Name { get; set; }
        [Required(ErrorMessage = "لطفا متن خود را وارد نمایید")]
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }= DateTime.Now;
  
        public int ProductId {  get; set; }
     
        public Book ? book { get; set; }
        public int Rating { get; set; }
    }
}
