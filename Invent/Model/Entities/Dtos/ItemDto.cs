namespace Model.Entities.Dtos;

public class ItemDto {
    // DTO of Item.cs
    public string Name { get; set; }
    public string? Description { get; set; }
    public DateTime AddedAt { get; set; }
    public string Code { get; set; }
    public bool IsMissing { get; set; }
    public string ItemType { get; set; }

    public Item ToItem() => new Item() {
        Name = this.Name,
        Description = this.Description,
        AddedAt = this.AddedAt,
        Code = this.Code,
        IsMissing = this.IsMissing,
        ItemType = Enum.Parse<EItemType>(this.ItemType)
    };
}