using UnityEngine;

public class HitboxScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.root == transform.root) 
            return;

        HealthScript victimHealth = other.GetComponent<HealthScript>();
        if (!victimHealth)
            return;
        
        if(other.CompareTag("Player"))
        {
            victimHealth.takeDamage(GetComponentInParent<EnemyBase>().getDamage());
            return;
        }
        else
        {
            victimHealth.takeDamage(GetComponentInParent<PlayerMovement>().getPunchDamage());
            return;
        }
            
    }
}
