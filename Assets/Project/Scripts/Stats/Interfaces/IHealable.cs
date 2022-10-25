public interface IHealable
{
    void HealDamage(int amount);
    /// <summary>
    /// Heals a percentage of character's max health.
    /// </summary>
    /// <param name="percent">The percent of max health to heal by.</param>
    void HealPercentage(float percent);
}
