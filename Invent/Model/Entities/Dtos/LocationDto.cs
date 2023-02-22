namespace Model.Entities.Dtos; 

public class LocationDto {
    // DTO of Location.cs
    public string Name { get; set; }
    public string? Address { get; set; }
    public bool IsRemote { get; set; }
    public List<ItemDto> Items { get; set; }

    public Location ToLocation() => new Location {
        Name = this.Name,
        Address = this.Address,
        IsRemote = this.IsRemote,
        Items = this.Items.Select(i => i.ToItem()).ToList()
    };
}