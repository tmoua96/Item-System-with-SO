[System.Serializable]
public class StatModifier
{
    private float value;
    private StatModifierType type;
    private int order;
    private object source;

    public float Value => value;
    public StatModifierType Type => type;
    public int Order => order;
    public object Source => source;

    /// <summary>
    /// A stat modifier for character stats.
    /// </summary>
    /// <param name="value">The amount to modify a stat by, percents based around 1 representing 100%(0.2 = 20%, 1.5 = 150%, etc.).</param>
    /// <param name="type">The type of stat modifier.</param>
    /// <param name="order">The order that a modifier should be applied to stats (ex. flat(index = 0) add before percent(index = 1))</param>
    public StatModifier(float value, StatModifierType type, int order, object source)
    {
        this.value = value;
        this.type = type;
        this.order = order;
        this.source = source;
    }

    /// <summary>
    /// A stat modifier for character stats.
    /// </summary>
    /// <param name="value">The amount to modify a stat by, percents based around 1 representing 100%(0.2 = 20%, 1.5 = 150%, etc.).</param>
    /// <param name="type">The type of stat modifier.</param>
    public StatModifier(float value, StatModifierType type) : this(value, type, (int)type, null) { }

    /// <summary>
    /// A stat modifier for character stats.
    /// </summary>
    /// <param name="value">The amount to modify a stat by, percents based around 1 representing 100%(0.2 = 20%, 1.5 = 150%, etc.).</param>
    /// <param name="type">The type of stat modifier.</param>
    /// <param name="order">The order that a modifier should be applied to stats (ex. flat(index = 0) add before percent(index = 1))</param>
    public StatModifier(float value, StatModifierType type, int order) : this(value, type, order, null) { }

    /// <summary>
    /// A stat modifier for character stats.
    /// </summary>
    /// <param name="value">The amount to modify a stat by, percents based around 1 representing 100%(0.2 = 20%, 1.5 = 150%, etc.).</param>
    /// <param name="type">The type of stat modifier.</param>
    /// <param name="order">The order that a modifier should be applied to stats (ex. flat(index = 0) add before percent(index = 1))</param>
    public StatModifier(float value, StatModifierType type, object source) : this(value, type, (int)type, source) { }
}

public enum StatModifierType
{
    Flat = 100,
    PercentAdditive = 200,
    PercentMultiplicative = 300
}