using UnityEngine;

[CreateAssetMenu(menuName = "Use Action/Stat Modifier/Heal Use")]
public class HealUse : Use
{
    [SerializeField]
    private int healAmount;

    public override void UseEffect(MonoBehaviour user)
    {
        if (user == null)
            return;
        if(user.TryGetComponent<IHealable>(out var healable))
            healable.HealDamage(healAmount);
    }
}