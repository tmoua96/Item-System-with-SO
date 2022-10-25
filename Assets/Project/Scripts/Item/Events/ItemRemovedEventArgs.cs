using System;

public class ItemRemovedEventArgs : EventArgs
{
    public readonly Item RemovedItem;

    public ItemRemovedEventArgs(Item removedItem)
    {
        RemovedItem = removedItem;
    }
}
