using System.ComponentModel.DataAnnotations;

namespace DatAccess.Models;

public class Authore
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Book>? Books { get; set; }
}
