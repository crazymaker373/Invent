using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("ITEMS")]
public class Item {
    [Column("ID")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("NAME", TypeName = "VARCHAR(45)")]
    [Required]
    public string Name { get; set; }

    [Column("DESCRIPTION", TypeName = "VARCHAR(45)")]
    public string Description { get; set; }

    [Column("ADDED_AT")] public DateTime AddedAt { get; set; } = DateTime.Now;

    [Column("CODE", TypeName = "VARCHAR(45)")]
    [Required]
    public string Code { get; set; }

    [Column("IS_MISSING")] public bool IsMissing { get; set; } = false;

    [Column("ITEM_TYPE")] [Required] public EItemType ItemType { get; set; }

    [Column("LOCATION_ID")] public int LocationId { get; set; }

    public Location Location { get; set; }
}