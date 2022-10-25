using UnityEngine;

[CreateAssetMenu(menuName = "Use Action/Stat Modifier/Damage Use")]
public class DamageUse : Use
{
    [SerializeField]
    private int damageAmount;

    public override void UseEffect(MonoBehaviour user)
    {
        if (user == null)
            return;
        if (user.TryGetComponent<IDamageable>(out var damageable))
            damageable.TakeDamage(damageAmount);
    }
}
