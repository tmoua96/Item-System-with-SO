using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField]
    private ItemSO item;

    private void Start()
    {
        Instantiate(item.ItemPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
