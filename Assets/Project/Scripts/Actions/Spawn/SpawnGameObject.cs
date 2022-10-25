using UnityEngine;

public class SpawnGameObject : Use
{
    [SerializeField]
    private GameObject spawnGameObject;

    public override void UseEffect(MonoBehaviour user)
    {
        Instantiate(spawnGameObject, user.transform.position, user.transform.rotation);
    }
}
