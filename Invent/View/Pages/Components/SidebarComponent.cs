using Domain.Services;
using Microsoft.AspNetCore.Components;
using Model.Entities.Components;

namespace View.Pages.Components;

public class SidebarComponent : ComponentBase {
    protected List<SidebarItem> SidebarItems { get; set; } = new();

    [Inject] public SidebarService SidebarService { get; set; } = null!;

    protected override void OnInitialized() {
        SidebarService.RefreshSidebar(SidebarItems);
    }

    protected override Task OnInitializedAsync() {
        SidebarService.RefreshSidebar(SidebarItems);
        return Task.CompletedTask;
    }
}