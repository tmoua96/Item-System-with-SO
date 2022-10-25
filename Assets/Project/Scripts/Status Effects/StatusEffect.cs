using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Stats/Status Effect")]
public class StatusEffect : ScriptableObject, IComparable
{
    [SerializeField]
    private new string name;
    [SerializeField][Multiline]
    private string description;
    [SerializeField]
    private Material statusMaterial;

    [SerializeField]
    private Use[] onApplyUses;
    [SerializeField]
    private Use[] onUpdateUses;
    [SerializeField]
    private Use[] onRemoveUses;

    public void ApplyStatusEffect(StatusEffectManager stats)
    {
        for (int i = 0; i < onApplyUses.Length; i++)
        {
            onApplyUses[i].UseEffect(stats);
        }
    }

    public void UpdateStatusEffect(StatusEffectManager stats)
    {
        for (int i = 0; i < onUpdateUses.Length; i++)
        {
            onUpdateUses[i].UseEffect(stats);
        }
    }

    public void OnRemoveStatusEffect(StatusEffectManager stats)
    {
        for (int i = 0; i < onRemoveUses.Length; i++)
        {
            onRemoveUses[i].UseEffect(stats);
        }
    }

    public int CompareTo(object obj)
    {
        if (obj == null)
            return 0;
        
        StatusEffect statusEffect = null;
        if (obj is StatusEffect)
            statusEffect = (StatusEffect)obj;

        return name.CompareTo(statusEffect.name);
    }
}
