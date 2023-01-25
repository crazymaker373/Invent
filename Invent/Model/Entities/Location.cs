﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Entities.Dtos;

namespace Model.Entities;

[Table("LOCATIONS")]
public class Location {
    [Column("ID")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("NAME", TypeName = "VARCHAR(45)")]
    [Required]
    public string Name { get; set; }
    

    [Column("ADDRESS", TypeName = "VARCHAR(45)")]
    [Required]
    public string Address { get; set; }

    [Column("IS_REMOTE")] [Required] public bool IsRemote { get; set; }

    [Column("INVENTORY_ID")] public int InventoryId { get; set; }

    public Inventory Inventory { get; set; }

    public ICollection<Item> Items { get; set; } = new List<Item>();
    
    public LocationDto ToDto() {
        return new LocationDto {
            Id = Id,
            Name = Name,
            Address = Address,
            IsRemote = IsRemote,
            InventoryId = InventoryId,
            Items = Items.Select(i => i.ToDto()).ToList()
        };
    }
}