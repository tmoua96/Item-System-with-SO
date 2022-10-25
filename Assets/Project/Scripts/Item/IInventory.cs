using System;

public interface IInventory
{
    void AddItem(ItemSO item, int amount = 1);
    void RemoveItem(ItemSO item, int amount = 1);
    Item GetItem(Guid id);
    bool TryGetItem(Guid id, out Item item);
}
