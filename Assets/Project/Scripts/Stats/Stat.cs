using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField]
    protected int baseValue;
    public int BaseValue => baseValue;

    public int Value 
    {
        get
        {
            if (isDirty || lastBaseValue != baseValue)
            {
                lastBaseValue = baseValue;
                value = CalculateFinalValue();
                isDirty = false;
            }
            return value;
        } 
    }

    [SerializeField]
    protected int value;
    [SerializeField]
    protected int lastBaseValue = int.MinValue;
    [SerializeField]
    protected bool isDirty = false;

    [SerializeField]
    protected List<StatModifier> modifiers;
    public readonly ReadOnlyCollection<StatModifier> Modifiers;

    public Stat()
    {
        modifiers = new List<StatModifier>();
        Modifiers = modifiers.AsReadOnly();
    }

    public Stat(int baseValue) : this()
    {
        this.baseValue = baseValue;
        value = baseValue;
    }

    public Stat(Stat stat)
    {
        baseValue = stat.baseValue;
        value = stat.value;
        lastBaseValue = stat.lastBaseValue;
        isDirty = stat.isDirty;
        modifiers = stat.modifiers;
        Modifiers = stat.modifiers.AsReadOnly();
    }

    public int CalculateFinalValue()
    {
        int finalValue = baseValue;
        float sumPercentAdd = 0;

        for (int i = 0; i < modifiers.Count; i++)
        {
            StatModifier modifier = modifiers[i];

            switch (modifier.Type)
            {
                case StatModifierType.Flat:
                    finalValue += Mathf.RoundToInt(modifier.Value);

                    break;
                case StatModifierType.PercentAdditive:
                    sumPercentAdd += modifier.Value;

                    if (i + 1 >= modifiers.Count || modifiers[i + 1].Type != StatModifierType.PercentAdditive)
                    {
                        finalValue = Mathf.RoundToInt(finalValue * (1 + sumPercentAdd));
                        sumPercentAdd = 0;
                    }

                    break;
                case StatModifierType.PercentMultiplicative:
                    finalValue = Mathf.RoundToInt(finalValue * (1 + modifier.Value));

                    break;
            }
        }

        return finalValue;
    }

    public void AddModifier(StatModifier modifier)
    {
        if (modifier == null)
            return;

        isDirty = true;
        modifiers.Add(modifier);
        modifiers.Sort(CompareModifierOrder);
    }

    public bool RemoveModifier(StatModifier modifier)
    {
        if (modifiers.Remove(modifier))
        {
            isDirty = true;
            return true;
        }

        return false;
    }

    public bool RemoveAllModifiersFromSource(object source)
    {
        bool removed = false;

        for(int i = modifiers.Count - 1; i >= 0; i--)
        {
            if(modifiers[i].Source == source)
            {
                isDirty = true;
                removed = true;
                modifiers.RemoveAt(i);
            }
        }

        return removed;
    }

    private int CompareModifierOrder(StatModifier a, StatModifier b)
    {
        if (a.Value < b.Value)
            return -1;
        else if (a.Value > b.Value)
            return 1;
        else
            return 0;
    }
}
