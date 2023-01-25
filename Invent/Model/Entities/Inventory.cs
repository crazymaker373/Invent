using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Entities.Dtos;

namespace Model.Entities;

[Table("INVENTORIES")]
public class Inventory {
    [Column("ID")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("NAME")] [Required] public string Name { get; set; }

    [Column("CREATED_AT")] public DateTime CreatedAt { get; set; } = DateTime.Now;

    [Column("LAST_EDIT")] public DateTime LastEdit { get; set; } = DateTime.Now;

    public ICollection<Location> Locations { get; set; } = new List<Location>();
    
    public InventoryDto ToDto() {
        return new InventoryDto {
            Id = Id,
            Name = Name,
            CreatedAt = CreatedAt,
            LastEdit = LastEdit,
            Locations = Locations.Select(l => l.ToDto()).ToList()
        };
    }
}