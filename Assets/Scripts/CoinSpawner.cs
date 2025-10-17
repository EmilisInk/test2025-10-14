using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    private bool alreadySpawned = false;
    public Transform spawnPoint;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!alreadySpawned && collision.gameObject.CompareTag("Player"))
        {
            alreadySpawned = true;
            SpawnCoin();
        }

    }

    private void SpawnCoin()
    {
        Instantiate(coinPrefab, spawnPoint.position, Quaternion.identity);
    }
}
