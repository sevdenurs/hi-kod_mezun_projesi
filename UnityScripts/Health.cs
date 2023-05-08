using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 100;
    [SerializeField] private Animator animatorController;
    private BoxCollider2D boxCollider2D;
    private int MAX_HEALTH = 100;

    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            // Damage
            // (10);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            // Heal(10);
        }
    }

    public void Damage(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
        }
        StopCoroutine(nameof(HitAnimation));
        StartCoroutine(nameof(HitAnimation));
        this.health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative healing");
        }

        bool wouldBeOverMaxHealth = health + amount > MAX_HEALTH;

        if (wouldBeOverMaxHealth)
        {
            this.health = MAX_HEALTH;
        }
        else
        {
            this.health += amount;
        }
    }

    private void Die()
    {
        if(animatorController != null)
        {
            animatorController.SetBool("isDead", true);
            boxCollider2D.isTrigger = true;
        }
    }

    IEnumerator HitAnimation()
    {
        animatorController.SetBool("gotHit", true);

        yield return new WaitForSeconds(0.25f);

        animatorController.SetBool("gotHit", false);
    }
}
