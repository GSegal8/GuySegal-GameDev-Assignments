using UnityEngine;

public class RangeDetector : MonoBehaviour
{
    private EnemyBase _enemyBase;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _enemyBase = GetComponentInParent<EnemyBase>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            _enemyBase.isPlayerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            _enemyBase.isPlayerInRange = false;
    }
}
