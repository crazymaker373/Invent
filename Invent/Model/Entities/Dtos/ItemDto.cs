namespace Model.Entities.Dtos; 

public class ItemDto {
    // DTO of Item.cs
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public DateTime AddedAt { get; set; }
    public string Code { get; set; }
    public bool IsMissing { get; set; }
    public EItemType ItemType { get; set; }
    public int LocationId { get; set; }
    
    void FromItem(Item item) {
        Id = item.Id;
        Name = item.Name;
        Description = item.Description;
        AddedAt = item.AddedAt;
        Code = item.Code;
        IsMissing = item.IsMissing;
        ItemType = item.ItemType;
        LocationId = item.LocationId;
    }
}