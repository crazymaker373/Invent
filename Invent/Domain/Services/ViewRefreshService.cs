namespace Domain.Services; 

public class ViewRefreshService {
    public event Action? HandleViewChange;
    
    public void RefreshView() {
        HandleViewChange?.Invoke();
    }
}