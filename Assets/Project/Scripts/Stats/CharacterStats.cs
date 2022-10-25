using UnityEngine;
using ScriptableObjectArchitecture;

public class CharacterStats : MonoBehaviour, IDamageable, IHealable
{
    [SerializeField]
    private int maxHealth = 100;

    public int CurrentHealth { get; private set; }
    public int MaxHealth { get { return maxHealth; } set { maxHealth = value; } }

    [SerializeField]
    private BaseStatValues baseStats;

    public Stat Strength { get; private set; }
    public Stat Agility { get; private set; }
    public Stat Intellect { get; private set; }
    public Stat Vitality { get; private set; }
    public Stat Defense { get; private set; }

    [SerializeField]
    private CharacterHealthDataGameEvent healthChangedEvent;

    [SerializeField]
    [Header("Debugging")]
    private Logging logger;

    private void Start()
    {
        SetCurrentHealth(maxHealth);
        InitializeStats();
    }

    private void Update()
    {
        // TODO - take out this test code later
        if (Input.GetKeyDown(KeyCode.U))
        {
            TakeDamage(Strength.Value);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            TakeDamageFromPercent(0.2f);
        }
    }

    private void InitializeStats()
    {
        Strength = new(baseStats.Power);
        Agility = new(baseStats.Agility);
        Intellect = new(baseStats.Intellect);
        Vitality = new(baseStats.Vitality);
        Defense = new(baseStats.Defense);
    }

    private void SetCurrentHealth(int amount)
    {
        amount = Mathf.Clamp(amount, 0, MaxHealth);
        CurrentHealth = amount;
        healthChangedEvent.Raise(new CharacterHealthData(CurrentHealth, maxHealth));
    }

    public void TakeDamage(int damage)
    {
        damage -= Defense.Value;

        if (damage < 0)
        {
            HealDamage(-damage);
            return;
        }

        SetCurrentHealth(CurrentHealth - damage);

        if (CurrentHealth <= 0)
        {
            SetCurrentHealth(0);
            Die();
        }

        logger?.Log($"{transform.name} takes {damage} damage.", this);
    }

    public void TakeDamageFromPercent(float percent)
    {
        int dmgFromPercent = Mathf.RoundToInt(CurrentHealth * percent);
        if (dmgFromPercent < 1)
            dmgFromPercent = 1;
        
        TakeDamage(dmgFromPercent);
    }

    public virtual void Die()
    {
        // This method may be overwritten
        logger?.Log($"{transform.name} died.", this);
    }

    public void HealDamage(int amount)
    {
        SetCurrentHealth(CurrentHealth + amount);
    }

    public void HealPercentage(float percent)
    {
        HealDamage(Mathf.RoundToInt((float)percent * maxHealth));
    }
}