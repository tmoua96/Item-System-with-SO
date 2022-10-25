using UnityEngine;

public class ItemPickup : MonoBehaviour, IInteractable
{
    [SerializeField]
    private ItemSO item;
    public ItemSO Item { get { return item; } }
    [SerializeField]
    private int amount;
    public int Amount { get { return amount; } }

    [SerializeField]
    private float maxInteractRange = 2;
    public float MaxInteractRange => maxInteractRange;

    private bool pickedUp;

    [SerializeField]
    private float rotationsPerSec;

    [SerializeField]
    private Logging logger;

    private void Update()
    {
        transform.Rotate(Vector3.up, rotationsPerSec * 360 * Time.deltaTime);
    }

    public void OnHover()
    {

    }

    public void Interact(MonoBehaviour user)
    {
        if (user.TryGetComponent<IInventory>(out var inventory))
            Pickup(inventory);
    }

    public void OnEndHover()
    {

    }

    private void Pickup(IInventory inventory)
    {
        inventory.AddItem(item, amount);
        gameObject.SetActive(false);
        pickedUp = true;    // TODO - to be used with saving data
    }
}