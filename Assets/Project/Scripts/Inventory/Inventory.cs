using UnityEngine;
using System.Collections.Generic;
using System;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Item System/Inventory")]
public class Inventory : ScriptableObject
{
    [SerializeField]
    private int size = 20;
    [SerializeField]
    private List<Item> items = new List<Item>();

    public int RemainingSpace { get { return size - items.Count; } }
    public bool IsFull { get { return items.Count >= size; } }

    /// <summary>
    /// Returns a copy of the items in the inventory.
    /// </summary>
    public Item[] Items
    {
        get
        {
            Item[] itemsArray = new Item[items.Count];
            for (int i = 0; i < items.Count; i++)
            {
                itemsArray[i] = new Item(items[i].ItemSO, items[i].Amount);
            }
            return itemsArray;
        }
    }

    public event EventHandler<ItemAddedEventArgs> ItemAdded;
    public event EventHandler<ItemRemovedEventArgs> ItemRemoved;

    /// <summary>
    /// Add an item to the inventory.
    /// </summary>
    /// <param name="item">The item to be added.</param>
    /// <param name="amountToAdd">The amount of an item to be added.</param>
    /// <returns>The item that was added, else null.</returns>
    public Item AddItem(ItemSO itemSO, int amountToAdd = 1)
    {
        if (IsFull)
            return null;
        amountToAdd = Mathf.Clamp(amountToAdd, 1, int.MaxValue);

        if (TryGetItem(itemSO, out Item item))
        {
            if (itemSO.Unique)
                return null;
            else if (itemSO.Stackable && item.Amount < itemSO.MaxStackAmount)
                item.AddAmount(amountToAdd);
            else
                item.AddAmount(amountToAdd);
        }
        else
        {
            items.Add(new Item(itemSO, amountToAdd));
        }

        ItemAdded?.Invoke(this, new ItemAddedEventArgs(item));

        return item;
    }

    /// <summary>
    /// Remove an item from the inventory.
    /// </summary>
    /// <param name="item">The item to be removed</param>
    /// <returns>The item that was removed.</returns>
    public Item RemoveItem(ItemSO item, int amountToRemove = 1)
    {
        if (!HasItem(item))
            return null;

        if (TryGetItem(item, out Item i))
        {
            if (item.Unique || i.Amount <= amountToRemove)
                items.Remove(i);
            else
                i.RemoveAmount(amountToRemove);

            ItemRemoved?.Invoke(this, new ItemRemovedEventArgs(i));
        }

        return i;
    }

    private bool HasItem(ItemSO itemSO)
    {
        return items.Exists(item => item.ItemSO == itemSO);
    }

    private bool HasItem(Guid id)
    {
        return items.Exists(item => item.ItemSO.ID.Equals(id));
    }

    public bool TryGetItem(ItemSO itemSO, out Item item)
    {
        item = items.Find(i => i.ItemSO == itemSO);
        return item != null || item != default(Item);
    }

    public bool TryGetItem(Guid id, out Item item)
    {
        item = items.Find(i => i.ItemSO.ID.Equals(id));
        return item != null || item != default(Item);
    }

    public void Clear()
    {
        items.Clear();
    }

    public Item GetItem(ItemSO item)
    {
        TryGetItem(item, out Item i);
        return i;
    }

    public Item GetItem(Guid id)
    {
        TryGetItem(id, out Item i);
        return i;
    }
}
