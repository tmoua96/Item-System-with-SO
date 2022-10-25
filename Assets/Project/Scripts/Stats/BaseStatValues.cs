using UnityEngine;

[CreateAssetMenu(menuName = "Stats/Base Stats")]
public class BaseStatValues : ScriptableObject
{
    [SerializeField]
    private int basePower;
    [SerializeField]
    private int baseAgility;
    [SerializeField]
    private int baseIntellect;
    [SerializeField]
    private int baseVitality;
    [SerializeField]
    private int baseDefense;

    public int Power => basePower;
    public int Agility => baseAgility;
    public int Intellect => baseIntellect;
    public int Vitality => baseVitality;
    public int Defense => baseDefense;
}
