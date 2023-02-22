namespace Model.Entities.Dtos; 

public class InventoryDto {
    // DTO of Inventory.,cs
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public DateTime LastEdit { get; set; }
    public List<LocationDto> Locations { get; set; }

    public Inventory ToInventory() => new Inventory {
        Name = this.Name,
        CreatedAt = this.CreatedAt,
        LastEdit = this.LastEdit,
        Locations = this.Locations.Select(l => l.ToLocation()).ToList()
    };
}