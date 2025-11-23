using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] public float MovementSpeed = 0.1f;
    [SerializeField] private GameObject _player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (_player.transform.position - transform.position).normalized;
        transform.position += direction * MovementSpeed * Time.deltaTime;
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player collided with " + other.name);
            GameManager.Instance.lostGame();
        }
    }
}
