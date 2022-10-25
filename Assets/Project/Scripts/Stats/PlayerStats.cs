using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerStats : CharacterStats
{
    private void Start()
    {
        //EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
    }

    //private void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
    //{
    //    if (newItem != null)
    //    {
    //        armor.AddModifier(newItem.armorModifier);
    //        damage.AddModifier(newItem.damageModifier);
    //    }

    //    if(oldItem != null)
    //    {
    //        armor.RemoveModifier(oldItem.armorModifier);
    //        damage.RemoveModifier(oldItem.damageModifier);
    //    }
    //}

    //public override void Die()
    //{
    //    base.Die();
    //    // Kill the player
    //    PlayerManager.instance.KillPlayer();
    //}
}
