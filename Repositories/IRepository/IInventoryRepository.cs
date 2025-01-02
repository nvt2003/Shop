using BusinessObjects.DTOs;

namespace Repositories.IRepository
{
    public interface IInventoryRepository
    {
        List<InventoryViewModel> GetInventories(int page, int pageSize);
        InventoryViewModel GetInventoryById(int id);
        InventoryDTO CreateInventory(InventoryDTO inventoryDTO);
        InventoryDTO UpdateInventory(InventoryDTO inventoryDTO);
        bool HideInventory(int id);
    }
}
