using UnityEngine;
using System;

public class InventoryManager : MonoBehaviour, IInventory
{
    [SerializeField]
    private Inventory inventory;

    [SerializeField]
    private Logging logger;

    public Inventory GetInventory()
    {
        return inventory;
    }

    public void AddItem(ItemSO item, int amount = 1)
    {
        inventory.AddItem(item, amount);
    }

    public void RemoveItem(ItemSO item, int amount = 1)
    {
        inventory.RemoveItem(item, amount);
    }

    public Item GetItem(Guid id)
    {
        return inventory.GetItem(id);
    }

    public bool TryGetItem(Guid id, out Item item)
    {
        bool success = inventory.TryGetItem(id, out Item i);
        item = i;
        return success;
    }
}
