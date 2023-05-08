using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerAttack : MonoBehaviour

{
    [SerializeField] GameObject attackArea = default;
    private Animator _animator;
    private bool attacking = false;

    private float timeToAttack = 0.25f;
    private float timer = 0f;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }
 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }

        if (attacking)
        {
            timer += Time.deltaTime;

            if (timer >= timeToAttack)
            {
                timer = 0;
                _animator.SetBool("isAttacking", false);
                attacking = false;
                attackArea.SetActive(attacking);
            }
        }
    }

    private void Attack()
    {
        _animator.SetBool("isAttacking", true);
        attacking = true;
        attackArea.SetActive(attacking);
        Debug.Log("Saldırdı");
    }
}
