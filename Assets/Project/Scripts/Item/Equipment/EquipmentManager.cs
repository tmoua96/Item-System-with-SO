using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class EquipmentManager : MonoBehaviour
{
    [SerializeField]
    private List<EquipmentSO> equipmentList = new List<EquipmentSO>();
    public EquipmentSO[] Equipment 
    { 
        get 
        { 
            EquipmentSO[] equipment = new EquipmentSO[equipmentList.Count];
            equipmentList.CopyTo(equipment, 0);
            return equipment; 
        } 
    }

    [SerializeField]
    private EquipmentEventDataGameEvent equipmentChangedEvent;

    public void Equip(EquipmentSO equipment)
    {
        if (equipment == null)
            return;
        if (IsEquipmentTypeFilled(equipment))
        {
            EquipmentSO toRemove = equipmentList.Find(x => x.EquipmentType == equipment.EquipmentType);
            RemoveEquipment(toRemove);
        }

        AddEquipment(equipment); 

        equipmentChangedEvent?.Raise(new EquipmentEventData(Equipment));
    }

    public void Unequip(EquipmentSO equipment)
    {
        if (equipment == null || !equipmentList.Contains(equipment))
            return;

        RemoveEquipment(equipment);

        equipmentChangedEvent?.Raise(new EquipmentEventData(Equipment));
    } 

    private void AddEquipment(EquipmentSO equipment)
    {
        equipmentList.Add(equipment);
        AddEquipmentStats(equipment);
    }

    private void RemoveEquipment(EquipmentSO equipment)
    {
        equipmentList.Remove(equipment);
        RemoveEquipmentStats(equipment);
    }

    private bool IsEquipmentTypeFilled(EquipmentSO equipment)
    {
        foreach (var item in equipmentList)
        {
            if (item.EquipmentType == equipment.EquipmentType)
                return true;
        }

        return false;
    }

    private void AddEquipmentStats(EquipmentSO equipment)
    {
        // TODO - consider aking this addition of stats as part of the use on an EquipUse or something like that
        if (TryGetComponent<CharacterStats>(out var stats))
        {
            if (equipment.StrengthBonus != 0)
                stats.Strength.AddModifier(new StatModifier(equipment.StrengthBonus, StatModifierType.Flat, equipment));
            if (equipment.AgilityBonus != 0)
                stats.Agility.AddModifier(new StatModifier(equipment.AgilityBonus, StatModifierType.Flat, equipment));
            if (equipment.IntellectBonus != 0)
                stats.Intellect.AddModifier(new StatModifier(equipment.IntellectBonus, StatModifierType.Flat, equipment));
            if (equipment.VitalityBonus != 0)
                stats.Vitality.AddModifier(new StatModifier(equipment.VitalityBonus, StatModifierType.Flat, equipment));
            if (equipment.DefenseBonus != 0)
                stats.Defense.AddModifier(new StatModifier(equipment.DefenseBonus, StatModifierType.Flat, equipment));

            if (equipment.StrengthPercentBonus != 0)
                stats.Strength.AddModifier(new StatModifier(equipment.StrengthPercentBonus, StatModifierType.PercentMultiplicative, equipment));
            if (equipment.AgilityPercentBonus != 0)
                stats.Agility.AddModifier(new StatModifier(equipment.AgilityPercentBonus, StatModifierType.PercentMultiplicative, equipment));
            if (equipment.IntellectPercentBonus != 0)
                stats.Intellect.AddModifier(new StatModifier(equipment.IntellectPercentBonus, StatModifierType.PercentMultiplicative, equipment));
            if (equipment.VitalityPercentBonus != 0)
                stats.Vitality.AddModifier(new StatModifier(equipment.VitalityPercentBonus, StatModifierType.PercentMultiplicative, equipment));
            if (equipment.DefensePercentBonus != 0)
                stats.Defense.AddModifier(new StatModifier(equipment.DefensePercentBonus, StatModifierType.PercentMultiplicative, equipment));
        }
    }

    private void RemoveEquipmentStats(EquipmentSO equipment)
    {
        if (TryGetComponent<CharacterStats>(out var stats))
        {
            stats.Strength.RemoveAllModifiersFromSource(equipment);
            stats.Agility.RemoveAllModifiersFromSource(equipment);
            stats.Intellect.RemoveAllModifiersFromSource(equipment);
            stats.Vitality.RemoveAllModifiersFromSource(equipment);
            stats.Defense.RemoveAllModifiersFromSource(equipment);
        }
    }
}