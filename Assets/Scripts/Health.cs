using System;
using UnityEngine;
using UnityEngine.Events;

public abstract class Health : MonoBehaviour
{
    public float health;
    public float maxHealth;

    [SerializeField] internal GameObject dieEffect;
    [SerializeField] internal GameObject damageEffect;
    [SerializeField] internal RandomSound damageSound;
    [SerializeField] internal RandomSound dieSound;

    public UnityEvent<float, float> OnHealthChanged;
    public UnityEvent OnDie;

    internal bool canTakeHit = true;

    private void Start()
    {
        var killed = FindObjectsOfType<EnemiesKilled>();
        foreach (var item in killed) OnDie.AddListener(() => item.CheckDeads());
        health = maxHealth;
    }

    public virtual void ChangeHealth(float value)
    {
        if(!canTakeHit) return;
        health += value;
        health = Mathf.Clamp(health, 0, maxHealth);
        OnHealthChanged?.Invoke(health, maxHealth);
        if (damageEffect != null) Instantiate(damageEffect, transform.position, Quaternion.identity);
        if(damageSound != null) damageSound.Play();
        if (health == 0)
        {
            Die();
            return;
        }
    }

    public virtual void Die()
    {
        OnDie?.Invoke();
        if(dieSound != null) dieSound.Play();
        if(dieEffect != null) Instantiate(dieEffect, transform.position, Quaternion.identity);
    }

    public void TakeHitState(bool state) => canTakeHit = state;
}
