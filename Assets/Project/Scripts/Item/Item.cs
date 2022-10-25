using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item
{
    [SerializeField]
    private ItemSO itemSO;
    public ItemSO ItemSO { get { return itemSO; } }

    [SerializeField]
    private int amount;
    public int Amount { get { return amount; } }

    public Item()
    {
        itemSO = null;
        amount = 0;
    }

    public Item(ItemSO itemSO, int amount = 1)
    {
        this.itemSO = itemSO;
        this.amount = amount;
    }

    public void AddAmount(int amount)
    {
        this.amount += amount;
    }

    public void RemoveAmount(int amount)
    {
        this.amount -= amount;
    }

    public override bool Equals(object obj)
    {
        return obj is Item item &&
               EqualityComparer<ItemSO>.Default.Equals(ItemSO, item.ItemSO);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(ItemSO);
    }
}
