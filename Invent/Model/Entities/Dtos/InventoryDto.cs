namespace Model.Entities.Dtos; 

public class InventoryDto {
    // DTO of Inventory.,cs
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public DateTime LastEdit { get; set; }
    public List<LocationDto> Locations { get; set; }
    
    void FromInventory(Inventory inventory) {
        Id = inventory.Id;
        Name = inventory.Name;
        CreatedAt = inventory.CreatedAt;
        LastEdit = inventory.LastEdit;
        Locations = inventory.Locations.Select(l => l.ToDto()).ToList();
    }
}