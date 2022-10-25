using UnityEngine;

[CreateAssetMenu(menuName = "Use Action/Stat Modifier/Stat Modifier")]
public class StatModifierUse : Use
{
    [SerializeField]
    private float amount;
    [SerializeField]
    private StatModifierType modifierType;
    [SerializeField]
    private StatModifierCategory category;

    public override void UseEffect(MonoBehaviour user)
    {
        if (user == null)
            return;
        if (user.TryGetComponent<CharacterStats>(out var stats) == false)
            return;

        switch (category)
        {
            case StatModifierCategory.Strength:
                stats.Strength.AddModifier(new StatModifier(amount, modifierType, this));
                break;
            case StatModifierCategory.Agility:
                stats.Agility.AddModifier(new StatModifier(amount, modifierType, this));
                break;
            case StatModifierCategory.Intellect:
                stats.Intellect.AddModifier(new StatModifier(amount, modifierType, this));
                break;
            case StatModifierCategory.Vitality:
                stats.Vitality.AddModifier(new StatModifier(amount, modifierType, this));
                break;
            case StatModifierCategory.Defense:
                stats.Defense.AddModifier(new StatModifier(amount, modifierType, this));
                break;
        }
    }

    public enum StatModifierCategory
    { 
        Strength,
        Agility,
        Intellect,
        Vitality,
        Defense
    }
}
