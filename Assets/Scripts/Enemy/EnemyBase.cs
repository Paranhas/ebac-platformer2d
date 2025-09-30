using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public string triggerDeath = "Death";
    public float timeToDestroy = 0.3f;
    public AudioSource audioSourceKill;
    private void Awake()
    {
        if(healthBase != null)
        {
            healthBase.OnKill += OnEnemyKill;
        }
    }

    public int damage = 10;
    public Animator animator;
    public string triggerAttack = "Attack";
    public HealthBase healthBase;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        var health = collision.gameObject.GetComponent<HealthBase>();
        if(health != null)
        {
            health.Damage(damage);
            PlayAttackAnimation();
        }
    }
    private void PlayAttackAnimation()
    {
        animator.SetTrigger(triggerAttack);
    }
    public void Damage(int amount)
    {
        healthBase.Damage(amount);
    }
    private void OnEnemyKill()
    {
        healthBase.OnKill -= OnEnemyKill;
        PlayDeathAnimation();
        if (audioSourceKill != null) audioSourceKill.Play();
        Destroy(gameObject, timeToDestroy);
    }

    private void PlayDeathAnimation()
    {
        animator.SetTrigger(triggerDeath);
    }
}
