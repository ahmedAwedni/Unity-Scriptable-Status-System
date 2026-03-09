# Unity Scriptable Status System

A modular, ScriptableObject-based system for managing buffs, debuffs, and timed status effects on any game entity.

---

## ✨ Features

* **ScriptableObject Driven:** Create new effects (Poison, Speed Boost, Freeze) in the Project window without writing new code.
* **Highly Decoupled:** The StatusReceiver handles the timers, while the StatusEffect handles the logic.
* **Stackable:** Supports multiple simultaneous effects out of the box.
* **Zero Boilerplate:** No more massive switch statements in your Player Controller.

---

## 🧠 Design Notes

This system utilizes the **Strategy Pattern**. Each StatusEffect is a strategy for how an entity's state should change over time.



By overriding the OnApply, OnTick, and OnRemove methods, you can create complex behaviors (like a burning effect that reduces health every second) while keeping the core engine lightweight.

---

## 🧩 How To Use

1. **Create an Effect:** Right-click in your Project window -> Status System -> New Effect.
2. **Setup Receiver:** Add the StatusReceiver component to your Player or Enemy.
3. **Trigger:** Call receiver.ApplyEffect(myEffect) from an area-of-effect trigger, a potion, or an enemy attack.
4. **Extend:** Inherit from StatusEffect to create specific logic (e.g., PoisonEffect : StatusEffect).

---

## 🚀 Possible Extensions

* **Effect Stacking:** Logic to determine if multiple instances of the same effect refresh the duration or stack intensity.
* **Visual FX:** Add a ParticleSystem field to the ScriptableObject to automatically spawn fire/sparks on the target.
* **UI Sync:** A delegate/event system to update a "Buff Bar" on the player's screen.

---

## 🛠 Unity Version

Tested in Unity 6 (should work fine with the newer versions)

---

## 📜 License

MIT
