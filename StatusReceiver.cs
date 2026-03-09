using System.Collections.Generic;
using UnityEngine;

public class StatusReceiver : MonoBehaviour
{
    private List<ActiveEffect> _activeEffects = new List<ActiveEffect>();

    public void ApplyEffect(StatusEffect effect)
    {
        ActiveEffect newEffect = new ActiveEffect(effect, gameObject);
        _activeEffects.Add(newEffect);
        effect.OnApply(gameObject);
    }

    void Update()
    {
        for (int i = _activeEffects.Count - 1; i >= 0; i--)
        {
            _activeEffects[i].UpdateEffect(Time.deltaTime);
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
    public bool IsFinished => RemainingTime <= 0;

    public ActiveEffect(StatusEffect data, GameObject target)
    {
        EffectData = data;
        RemainingTime = data.duration;
    }

    public void UpdateEffect(float deltaTime) => RemainingTime -= deltaTime;
}
