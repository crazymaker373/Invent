using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Entities.Dtos;

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
    public string Description { get; set; } = "";

    [Column("ADDED_AT")] public DateTime AddedAt { get; set; } = DateTime.Now;

    [Column("CODE", TypeName = "VARCHAR(45)")]
    [Required]
    public string Code { get; set; }

    [Column("IS_MISSING")] public bool IsMissing { get; set; }

    [Column("ITEM_TYPE")] [Required] public EItemType ItemType { get; set; }

    [Column("LOCATION_ID")] public int LocationId { get; set; }

    public Location Location { get; set; }
    
    public ItemDto ToDto() {
        return new ItemDto {
            Name = Name,
            Description = Description,
            AddedAt = AddedAt,
            Code = Code,
            IsMissing = IsMissing,
            ItemType = ItemType.ToString(),
        };
    }
}