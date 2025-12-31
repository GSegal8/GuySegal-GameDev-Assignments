using UnityEngine;
using UnityEngine.EventSystems;

public class CombatScript: MonoBehaviour
{
    public bool isAttacking = false;
    private Animator animator;
    PlayerMovement playerScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerScript = GetComponent<PlayerMovement>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
            return;
        
        if(!playerScript.IsAnimationFinised(animator, "PlayerPunch"))
            return;
        else
            endAttack();
        
        if (Input.GetMouseButtonDown(0) && !isAttacking)
        {
            playerAttack();
        }
    }

    public void playerAttack()
    {
        Debug.Log("Player Attacks");
        isAttacking = true;
        animator.SetTrigger("Attack");
    }
    public void endAttack()
    {
        isAttacking = false;
    }
}
