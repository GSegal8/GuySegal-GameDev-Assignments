using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 25f;
    Vector3 direction = Vector3.zero;
    [SerializeField] private int PunchDamage = 50;

    private Vector2 originalScale;
    private Rigidbody2D rb;
    private Animator animator;
    
    private Vector2 moveInput;
    private float horizontalInput;
    private float verticalInput;
    private bool isFacingRight = true;
    
    private CombatScript combatScript;
    private HealthScript healthScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        originalScale =  transform.localScale;
        combatScript = GetComponent<CombatScript>();
        healthScript = GetComponent<HealthScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (healthScript.isDead)
        {
            GameManager.Instance.ShowEndGame(false);
        }
        horizontalInput  = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        HandleMovement();
    }
    private void FixedUpdate()
    {
        if (combatScript.isAttacking)
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
            return;
        }
        rb.linearVelocity = new Vector2(horizontalInput * _speed, verticalInput * _speed);
    }
    
    private void HandleMovement()
    {
        flipCharacter();
        if (horizontalInput != 0)
            animator.SetBool("isWalking", true);
        else
            animator.SetBool("isWalking", false);
        
    }
    
    private void flipCharacter()
    {
        if ((isFacingRight && horizontalInput < 0) || (!isFacingRight && horizontalInput > 0))
        {
            Debug.Log("flipping character");
            isFacingRight = !isFacingRight;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }
    
    public bool IsAnimationFinised(Animator animator, string AnimationName)
    {
        AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
        
        if (!info.IsName(AnimationName)) return true;
        
        if (info.normalizedTime >= 1)
            return true;
        
        return false;
    }

    public int getPunchDamage()
    {
        return PunchDamage;
    }
}
