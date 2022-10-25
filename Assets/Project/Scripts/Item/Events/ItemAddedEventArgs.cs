using System;

public class ItemAddedEventArgs : EventArgs
{
    public readonly Item AddedItem;

    public ItemAddedEventArgs(Item addedItem)
    {
        AddedItem = addedItem;
    }
}
