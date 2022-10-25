using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class StatusEffectManager : MonoBehaviour
{
    public StatusEffect[] CurrentStatusEffects
    {
        get
        {
            StatusEffect[] effects = new StatusEffect[currentStatusEffects.Count];

            for (int i = 0; i < currentStatusEffects.Count; i++)
            {
                effects[i] = currentStatusEffects[i];
            }

            return effects;
        }
    }

    private List<StatusEffect> currentStatusEffects = new List<StatusEffect>();
    [SerializeField]
    private StatusEffect damageStatusEffect;
    [SerializeField]
    private StatusEffect healStatusEffect;

    [SerializeField]
    private StatusEffectEventDataGameEvent StatusChangedEvent;

    void Update()
    {
        // TODO - take out this testing code later
        if (Input.GetKeyDown(KeyCode.R))
        {
            ClearStatusEffects();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            ApplyStatusEffect(damageStatusEffect);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            ApplyStatusEffect(healStatusEffect);
        }
        if(currentStatusEffects.Count > 0)
        {
            for (int i = 0; i < currentStatusEffects.Count; i++)
            {
                currentStatusEffects[i].UpdateStatusEffect(this);
            }
        }
    }

    /// <summary>
    /// Apply a status effect. Reapplies a status effect if it's already active.
    /// </summary>
    /// <param name="statusEffect">The status effect to be applied.</param>
    public void ApplyStatusEffect(StatusEffect statusEffect)
    {
        if (statusEffect == null)
            return;
        if(currentStatusEffects.Contains(statusEffect))
            currentStatusEffects.Remove(statusEffect);

        currentStatusEffects.Add(statusEffect);
        statusEffect.ApplyStatusEffect(this);

        currentStatusEffects.Sort();

        StatusChangedEvent?.Raise(new StatusEffectEventData(CurrentStatusEffects));
    }

    public void RemoveStatusEffect(StatusEffect statusEffect)
    {
        if (!currentStatusEffects.Contains(statusEffect) || statusEffect is null)
            return;

        currentStatusEffects.Remove(statusEffect);
        statusEffect.OnRemoveStatusEffect(this);

        currentStatusEffects.Sort();

        StatusChangedEvent?.Raise(new StatusEffectEventData(CurrentStatusEffects));
    }

    public void ClearStatusEffects()
    {
        for(int i = currentStatusEffects.Count - 1; i >= 0; i--)
        {
            currentStatusEffects[i].OnRemoveStatusEffect(this);
        }
        currentStatusEffects.Clear();

        StatusChangedEvent?.Raise(new StatusEffectEventData(currentStatusEffects.ToArray()));
    }
}
