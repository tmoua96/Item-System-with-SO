using UnityEngine;

[CreateAssetMenu(menuName = "Use Action/Stat Modifier/Damage Percent Use")]
public class DamagePercentUse : Use
{
    [SerializeField, Range(0f, 1f)]
    private float percentAmount;

    public override void UseEffect(MonoBehaviour user)
    {
        if (user == null)
            return;
        if(user.TryGetComponent<IDamageable>(out var damageable))
            damageable?.TakeDamageFromPercent(percentAmount);
    }
}
