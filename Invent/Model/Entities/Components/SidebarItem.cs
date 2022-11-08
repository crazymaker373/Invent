namespace Model.Entities.Components; 

public class SidebarItem {

    public string Name { get; set; }

    public string Icon { get; set; } = "";
    
    public Action? OnClick { get; set; }
    
    public string? Link { get; set; }
}