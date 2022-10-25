using UnityEngine;

[CreateAssetMenu(menuName = "Use Action/Spawn/Spawn Particle Systems")]
public class SpawnParticlesUse : Use
{
    [SerializeField]
    private ParticleSystem[] particleSystems;

    public override void UseEffect(MonoBehaviour user)
    {
        foreach (var particle in particleSystems)
        {
            Instantiate(particle, user.transform.position, Quaternion.identity);
        }
    }
}
