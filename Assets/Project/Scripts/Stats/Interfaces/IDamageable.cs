public interface IDamageable
{
    /// <summary>
    /// Take damage from a flat amount.
    /// </summary>
    /// <param name="damage">The amount of damage to be dealt.</param>
    void TakeDamage(int damage);
    /// <summary>
    /// Take damage and reduce hit points by percentage, with value from 0 to 1.
    /// </summary>
    /// <param name="percent">The percentage of hit points to reduce(Value Range: 0 to 1).</param>
    void TakeDamageFromPercent(float percent);
}

public enum DamageType
{
    Flat,
    Percent
}