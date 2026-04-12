using System.Collections.Generic;
using UnityEngine;

public class StatusReceiver : MonoBehaviour
{
    private List<ActiveEffect> _activeEffects = new List<ActiveEffect>();

    public void ApplyEffect(StatusEffect effect)
    {
        // EXTENSION: Check if we should refresh duration instead of stacking
        if (!effect.stackable)
        {
            ActiveEffect existingEffect = _activeEffects.Find(e => e.EffectData == effect);
            if (existingEffect != null)
            {
                existingEffect.ResetDuration();
                Debug.Log($"{effect.effectName} duration refreshed!");
                return;
            }
        }

        // Otherwise, add it as a new effect
        ActiveEffect newEffect = new ActiveEffect(effect);
        _activeEffects.Add(newEffect);
        effect.OnApply(gameObject);
    }

    void Update()
    {
        for (int i = _activeEffects.Count - 1; i >= 0; i--)
        {
            _activeEffects[i].UpdateEffect(Time.deltaTime);

            // Trigger Tick logic based on tickInterval
            if (_activeEffects[i].ShouldTick())
            {
                _activeEffects[i].EffectData.OnTick(gameObject);
            }

            if (_activeEffects[i].IsFinished)
            {
                _activeEffects[i].EffectData.OnRemove(gameObject);
                _activeEffects.RemoveAt(i);
            }
        }
    }
}

public class ActiveEffect
{
    public StatusEffect EffectData;
    public float RemainingTime;
    private float _tickTimer;

    public bool IsFinished => RemainingTime <= 0;

    public ActiveEffect(StatusEffect data)
    {
        EffectData = data;
        RemainingTime = data.duration;
        _tickTimer = data.tickInterval;
    }

    public void ResetDuration()
    {
        RemainingTime = EffectData.duration;
    }

    public void UpdateEffect(float deltaTime)
    {
        RemainingTime -= deltaTime;
        _tickTimer -= deltaTime;
    }

    public bool ShouldTick()
    {
        if (EffectData.tickInterval <= 0) return false;

        if (_tickTimer <= 0)
        {
            _tickTimer = EffectData.tickInterval;
            return true;
        }
        return false;
    }
}
