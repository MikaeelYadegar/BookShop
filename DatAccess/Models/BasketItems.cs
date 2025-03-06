using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatAccess.Models
{
    public class BasketItems
    {
        [Key]
        public int Id { get; set; }
        public int BasketId { get; set; }
        public int BookId { get; set; }
        public int Price { get; set; }
        public int Qty { get; set; }
        public DateTime Created { get; set; }
        [ForeignKey("BasketId")]
        public Basket Basket { get; set; }
        [ForeignKey("BookId")]
        public Book Book { get; set; }
    }
}
