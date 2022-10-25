using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct DamageMessage
{
    /// <summary>
    /// The object that did the damage
    /// </summary>
    public MonoBehaviour damager;
    /// <summary>
    /// The amount of damage to do.
    /// </summary>
    public int amount;
    /// <summary>
    /// The amount to knockback(in percentage)
    /// </summary>
    public float knockbackAmount;
    /// <summary>
    /// The direction the attack is going.
    /// </summary>
    public Vector3 direction;   // TODO: probably change other classes so they can use this info to towards a certain direction
    /// <summary>
    /// The direction the attack is coming from. Use the attacker's position.
    /// </summary>
    public Vector3 damageSource;

    /// <summary>
    /// A damage message containing values of the damage amount, modifiers and the damager.
    /// </summary>
    /// <param name="stats">The stats of the attacker which contains their stats for damage and crit.</param>

    public DamageMessage(CharacterStats stats)  // TODO: add stuff for the direction and damageSource and such
    {
        damager = null;
        amount = stats.Strength.Value;
        knockbackAmount = 0;
        direction = Vector3.zero;
        damageSource = Vector3.zero;
    }

    /// <summary>
    /// A damage message containing values of the damage amount, modifiers and the damager.
    /// </summary>
    /// <param name="stats">The stats of the attacker which contains their stats for damage and crit.</param>
    /// <param name="damager">The monobehaviour attached to the attacker.</param>

    public DamageMessage(CharacterStats stats, MonoBehaviour damager)  // TODO: add stuff for the direction and damageSource and such
    {
        this.damager = damager;
        amount = stats.Strength.Value;
        knockbackAmount = 0;
        direction = Vector3.zero;
        damageSource = Vector3.zero;
    }

    /// <summary>
    /// A damage message containing values of the damage amount, modifiers and the damager.
    /// </summary>
    /// <param name="stats">The stats of the attacker which contains their stats for damage and crit.</param>
    /// <param name="knockbackAmount">The amount to knockback from the attacker's ability.</param>
    /// <param name="damager">The monobehaviour attached to the attacker.</param>

    public DamageMessage(CharacterStats stats, float knockbackAmount, MonoBehaviour damager)  // TODO: add stuff for the direction and damageSource and such
    {
        this.damager = damager;
        amount = stats.Strength.Value;
        this.knockbackAmount = knockbackAmount;
        direction = Vector3.zero;
        damageSource = Vector3.zero;
    }
}
