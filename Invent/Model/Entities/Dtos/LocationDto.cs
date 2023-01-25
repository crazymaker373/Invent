namespace Model.Entities.Dtos; 

public class LocationDto {
    // DTO of Location.cs
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Address { get; set; }
    public bool IsRemote { get; set; }
    public int InventoryId { get; set; }
    
    public List<ItemDto> Items { get; set; }
    
    void FromLocation(Location location) {
        Id = location.Id;
        Name = location.Name;
        Address = location.Address;
        IsRemote = location.IsRemote;
        InventoryId = location.InventoryId;
        Items = location.Items.Select(i => i.ToDto()).ToList();
    }
}