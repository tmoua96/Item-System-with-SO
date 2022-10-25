using UnityEngine;

[CreateAssetMenu(menuName = "Item System/Item/Equipment")]
public class EquipmentSO : ItemSO
{
    // TODO - possibly might be better to just bunch all the bonuses
    //        into a 'Use' subclass and have no subclasses of ItemSO. Bonuses would be
    //        added as a use of the item. This would allow for the weapon subclass to be removed
    //        as well.
    [SerializeField]
    protected int strengthBonus;
    [SerializeField]
    protected int agilityBonus;
    [SerializeField]
    protected int intellectBonus;
    [SerializeField]
    protected int vitalityBonus;
    [SerializeField]
    protected int defenseBonus;

    [SerializeField]
    protected float strengthPercentBonus;
    [SerializeField]
    protected float agilityPercentBonus;
    [SerializeField]
    protected float intellectPercentBonus;
    [SerializeField]
    protected float vitalityPercentBonus;
    [SerializeField]
    protected float defensePercentBonus;

    [SerializeField]
    protected EquipmentType equipmentType;

    public int StrengthBonus { get { return strengthBonus; } }
    public int AgilityBonus { get { return agilityBonus; } }
    public int IntellectBonus { get { return intellectBonus; } }
    public int VitalityBonus { get { return vitalityBonus; } }
    public int DefenseBonus { get { return defenseBonus; } }

    public float StrengthPercentBonus { get { return strengthPercentBonus; } }
    public float AgilityPercentBonus { get { return agilityPercentBonus;} }
    public float IntellectPercentBonus { get { return intellectPercentBonus; } }
    public float VitalityPercentBonus { get { return vitalityPercentBonus; } }
    public float DefensePercentBonus { get { return defensePercentBonus; } }

    public EquipmentType EquipmentType { get { return equipmentType; } }

    public override void UseItem(MonoBehaviour user)
    {
        base.UseItem(user);

        if (user.TryGetComponent<EquipmentManager>(out var equipmentManager))
            equipmentManager.Equip(this);
    }
}
