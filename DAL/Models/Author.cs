using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models;

public sealed class Author
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Required]
    [Column("name")]
    public string Name { get; set; }
    
    [Required]
    [Column("birth_date")]
    public DateTime BirthDate { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; set; } = false;
    public List<Book> Books { get; set; }
}
