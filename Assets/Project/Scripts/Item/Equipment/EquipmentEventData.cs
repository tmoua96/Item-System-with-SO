using UnityEngine;
using System;

[Serializable]
public class EquipmentEventData
{
    [SerializeField]
    private EquipmentSO[] equipment;
    public EquipmentSO[] Equipment => equipment;

    public EquipmentEventData(EquipmentSO[] equipment)
    {
        this.equipment = equipment;
    }
}
