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
        [Required]
        public string Name { get; set; }
        [Required]
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }= DateTime.Now;
  
        public int ProductId {  get; set; }
     
        public Book ? book { get; set; }
    }
}
