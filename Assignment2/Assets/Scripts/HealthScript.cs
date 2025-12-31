using System.Collections;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    private int maxHealth = 100;
    private int currentHealth;
    private bool isPlayer; //if false = enemy
    private Rigidbody2D rb;
    private Animator animator;
    EnemyBase eb;
    
    public bool isDead = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(gameObject.CompareTag("Player"))
            isPlayer = true;

        if (!isPlayer)
            eb = GetComponent<EnemyBase>();
        
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }
    void Update()
    {
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = currentHealth < 0 ? 0 : currentHealth;
        if(isPlayer)
            Debug.Log("Player Health: "+currentHealth);
        else
        {
            Debug.Log("Enemy Health: "+currentHealth);
            eb.resetAttack();
        }
        lifeCheck();
    }

    private void lifeCheck()
    {
        if (currentHealth <= 0)
        {
            Die();
            return;
        }
        if(!isPlayer)
            animator.SetTrigger("Hurt");
    }

    private void Die()
    {
        isDead = true;
        if (!isPlayer)
        {
            animator.SetTrigger("Dead");
        }
    }
    
}
