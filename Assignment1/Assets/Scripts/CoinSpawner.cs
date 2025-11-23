using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public static CoinSpawner Instance { get; private set; }
    [SerializeField] private GameObject bronzeCoinPrefab;
    [SerializeField] private GameObject silverCoinPrefab;
    [SerializeField] private GameObject goldCoinPrefab;
    [SerializeField] private Vector3 SpawnAreaMin;
    [SerializeField] private Vector3 SpawnAreaMax;
    [SerializeField] private int amountOfCoinsToSpawn = 5;
    private int liveCoins = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created}
    
    void Start()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
        spawnCoins();
    }

    // Update is called once per frame
    void Update()
    {
        if(liveCoins == 0)
            spawnCoins();
    }
    private void spawnCoins()
    {
        for (int i = 0; i < amountOfCoinsToSpawn; i++)
        { 
            liveCoins++;
            var x = Random.Range(SpawnAreaMin.x, SpawnAreaMax.x);
            var y = Random.Range(SpawnAreaMin.y, SpawnAreaMax.y);
            int value = Random.Range(1, 4);
            if (value == 1)
                Instantiate(bronzeCoinPrefab, new Vector3(x, y, 0), Quaternion.identity);
            else if (value == 2)
                Instantiate(silverCoinPrefab, new Vector3(x, y, 0), Quaternion.identity);
            else if (value == 3)
                Instantiate(goldCoinPrefab, new Vector3(x, y, 0), Quaternion.identity);
        }
    }
    private Vector3 RandomPointInBox(BoxCollider2D box)
    {
        Bounds b = box.bounds;
        float x = Random.Range(b.min.x, b.max.x);
        float y = Random.Range(b.min.y, b.max.y);
        return new Vector3(x, y, 0f);
    }
    public void DecreaseCoinLife()
    {
        liveCoins -= 1;
    }
}
