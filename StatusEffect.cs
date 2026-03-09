using UnityEngine;

[CreateAssetMenu(menuName = "Status System/New Effect")]
public class StatusEffect : ScriptableObject
{
    public string effectName;
    public float duration;
    public float tickInterval; // For things like poison damage

    public virtual void OnApply(GameObject target) => Debug.Log($"{effectName} applied!");
    public virtual void OnTick(GameObject target) { }
    public virtual void OnRemove(GameObject target) => Debug.Log($"{effectName} removed!");
}
