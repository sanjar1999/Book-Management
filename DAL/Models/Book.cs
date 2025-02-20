using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace DAL.Models;

public sealed class Book
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("title")]
    [MinLength(1)]
    [MaxLength(100)]
    public string Title { get; set; }

    [Required]
    [Column("published_date")]
    public DateTime PublishedDate { get; set; }

    [Column("views_count")]
    public int ViewsCount { get; set; }

    [Column("author_id")]
    [Required]
    public int AuthorId { get; set; }
    
    [IgnoreDataMember]
    [ForeignKey(nameof(AuthorId))]
    public Author Author { get; set; }
    public bool IsDeleted { get; set; } = false;
}
