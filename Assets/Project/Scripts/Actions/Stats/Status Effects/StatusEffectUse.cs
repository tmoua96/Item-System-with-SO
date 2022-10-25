using UnityEngine;

[CreateAssetMenu(menuName = "Use Action/Status Effect/Apply Status Effect Use")]
public class StatusEffectUse : Use
{
    [SerializeField, Tooltip("The status effect to apply on use.")]
    private StatusEffect statusEffect;

    public override void UseEffect(MonoBehaviour user)
    {
        if(user.TryGetComponent<StatusEffectManager>(out var manager))
        {
            manager.ApplyStatusEffect(statusEffect);
        }
    }
}
