using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatAccess.Models;

public class Book
{
    [Key]
    public int Id { get; set; } 
    public string Title { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public string Img { get; set; }
    public DateTime Created { get; set; }
    public bool IsAvail { get; set; }
    public bool ShowHomePage { get; set; }
    public int AuthoreId { get; set; }
    [ForeignKey("AuthoreId")]
    public Authore ? Authore { get; set; }
    public ICollection<BasketItems>? BasketItems { get; set; }
  
   
}
