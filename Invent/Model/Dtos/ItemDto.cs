namespace Model.Dtos; 

public record ItemDto(string name, string description, string addedAt, string code, bool isMissing, string itemType, string locationName, string locationAddress) {
    
}