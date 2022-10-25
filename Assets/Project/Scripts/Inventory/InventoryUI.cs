using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    private Inventory inventory;

    [SerializeField]
    private Image[] itemContainers;
    [SerializeField]
    private Image[] itemIcons;
    [SerializeField]
    private TextMeshPro amountText;

    private void Awake()
    {
        if (inventory == null)
        {
            inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryManager>().GetInventory();
        }

        inventory.ItemAdded += OnItemAdded;
        inventory.ItemRemoved += OnItemRemoved;
    }

    private void UpdateInventoryUI()
    {
        // TODO - update the inventory ui
    }

    private void OnItemAdded(object sender, ItemAddedEventArgs args)
    {
        // display item added stuff
        string addedMsg = $"Added {args.AddedItem} to inventory.";
        DisplayItemChangeText(addedMsg);

        UpdateInventoryUI();
    }

    private void OnItemRemoved(object sender, ItemRemovedEventArgs args)
    {
        // display item removed stuff
        string addedMsg = $"Removed {args.RemovedItem} from inventory.";
        DisplayItemChangeText(addedMsg);

        UpdateInventoryUI();
    }

    private void DisplayItemChangeText(string message)
    {

    }

    private void OnDestroy()
    {
        inventory.ItemAdded -= OnItemAdded;
        inventory.ItemRemoved -= OnItemRemoved;
    }
}
