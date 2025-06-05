using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatAccess.Models
{
    public class DiscountCode
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int Percentage {  get; set; }    
        public DateTime CreatedAt { get; set; }
        public DateTime ExpierAt { get; set; }
        public bool IsUsed {  get; set; }
    }
}
