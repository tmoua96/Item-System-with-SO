using UnityEngine;

[System.Serializable]
public struct CharacterHealthData
{
    [SerializeField]
    private int currentHealth;
    [SerializeField]
    private int maxHealth;

    public int CurrentHealth => currentHealth;
    public int MaxHealth => maxHealth;

    public CharacterHealthData(int currentHealth, int maxHealth)
    {
        this.currentHealth = currentHealth;
        this.maxHealth = maxHealth;
    }
}
