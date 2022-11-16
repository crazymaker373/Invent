using Model.Entities.Components;

namespace Domain.Services;

public class SidebarService {
    public List<SidebarItem> SidebarItems { get; set; } = new();

    public event Action? HandleSidebarChange;

    public void RefreshSidebar(List<SidebarItem> items) {
        SidebarItems = items;
        HandleSidebarChange?.Invoke();
    }
}