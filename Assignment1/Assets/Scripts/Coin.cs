using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public enum CoinType { Bronze, Silver, Gold };
    public int BronzeCoinValue = 25; public int SilverCoinValue = 50; public int GoldCoinValue = 100;
    public CoinType coinType;
    private CoinSpawner spawner;
    public int coinValue = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player collided with " + other.name);
            CollectCoin();
        }
    }

    private void CollectCoin()
    {
        if (coinType == CoinType.Bronze)
        {
            coinValue = BronzeCoinValue ;
        }

        if (coinType == CoinType.Silver)
        {
            coinValue = SilverCoinValue;
        }

        if (coinType == CoinType.Gold)
        {
            coinValue = GoldCoinValue;
        }
        GameManager.Instance.player.GetComponent<PlayerScript>().addScore(coinValue);
        Debug.Log("Decreasing live coins");
        CoinSpawner.Instance.DecreaseCoinLife();
        Debug.Log("Destroying coin");
        Destroy(gameObject);
    }
}
