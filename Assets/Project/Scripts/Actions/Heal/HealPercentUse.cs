using UnityEngine;

[CreateAssetMenu(menuName = "Use Action/Stat Modifier/Heal Percent Use")]
public class HealPercentUse : Use
{
    [SerializeField, Range(0, 1)]
    private float percentToHeal;

    public override void UseEffect(MonoBehaviour user)
    {
        if (user == null)
            return;
        if (user.TryGetComponent<IHealable>(out var healable))
            healable.HealPercentage(percentToHeal);
    }
}
