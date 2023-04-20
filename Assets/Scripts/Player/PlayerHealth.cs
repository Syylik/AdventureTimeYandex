using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField] private float _healthLoseSpeed;
    private float _healthAfter;
    private RandomSound damageSound;

    private void Start() => _healthAfter = health;

    private void Update()
    {
        health = Mathf.MoveTowards(health, _healthAfter, _healthLoseSpeed * Time.deltaTime);
        OnHealthChanged?.Invoke(health, maxHealth);
        health = Mathf.Clamp(health, 0, maxHealth);
        if(health == 0) Die();
    }

    public override void ChangeHealth(float value)
    {
        if(!canTakeHit) return; 
        _healthAfter = health + value;
        if(_healthAfter > 0 && damageSound != null) damageSound.Play();
    }

    public override void Die()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        base.Die();
    }
}
