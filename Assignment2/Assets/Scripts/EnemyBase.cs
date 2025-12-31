using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [Header("Enemy Settings")]
    [SerializeField] private float _speed = 0.05f;
    [SerializeField] protected int damage = 30;
    private float attackCooldown = 2f;
    
    private Rigidbody2D rb;
    Animator anim;
    private Coroutine attackCoroutine;
    private GameObject player;
    private HealthScript healthScript;
    
    public bool isPlayerInRange = false;
    private bool isAttacking = false;
    private bool isFacingRight = false;
    private Vector2 originalScale;
    
    void Start()
    {
        rb =  GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        healthScript = GetComponent<HealthScript>();
        originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (healthScript.isDead)
        {
            rb.linearVelocity = Vector2.zero;
            if(!IsAnimationFinised(anim,"Enemy_Die"))
                return;
            else
                GameManager.Instance.ShowEndGame(true);
        }
        Vector2 direction = (player.transform.position - transform.position).normalized;
        FlipCharacter(direction.x);
        if (isPlayerInRange)
        {
            anim.SetBool("isWalking", false);
            rb.linearVelocity = Vector2.zero;
            if (!isAttacking && !(anim.GetCurrentAnimatorStateInfo(0).IsName("Enemy_Hurt") && !IsAnimationFinised(anim,"Enemy_Hurt")))
            {
                isAttacking = true;
                attackCoroutine = StartCoroutine(Attack());
            }
        }
        else
        {
            rb.linearVelocity = new Vector2(direction.x * _speed, direction.y * _speed);
            anim.SetBool("isWalking", true);
        }
    }
    private void FlipCharacter(float moveX)
    {
        if (moveX > 0 && !isFacingRight || moveX < 0 && isFacingRight)
        {
            float right = isFacingRight ? 1 : -1;
            transform.localScale = new Vector3(originalScale.x * right, originalScale.y);
            isFacingRight = !isFacingRight;
        }
    }
    
    IEnumerator Attack()
    {
        Debug.Log("Enemy attacks for " + damage + " damage!");
        anim.SetTrigger("Attack");
        yield return new WaitForSeconds(attackCooldown);
        isAttacking = false;
    }

    public void resetAttack()
    {
        if (attackCoroutine != null)
            StopCoroutine(attackCoroutine);
        isAttacking = false;
    }

    public int getDamage()
    {
        return damage;
    }
    public bool IsAnimationFinised(Animator animator, string AnimationName)
    {
        AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
        
        if (!info.IsName(AnimationName)) return false;
        
        if (info.normalizedTime >= 1)
            return true;
        
        return false;
    }
}
