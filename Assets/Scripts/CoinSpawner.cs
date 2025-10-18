using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public Mesh meshToChangeTo;
    private bool alreadySpawned = false;
    public Transform spawnPoint;
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (!alreadySpawned && collision.collider.CompareTag("Player"))
        {
            Vector2 direction = collision.GetContact(0).normal;
            if (direction.y == 1)
            {
                alreadySpawned = true;
                SpawnCoin();
                MeshFilter mf = GetComponent<MeshFilter>();
                mf.mesh = meshToChangeTo;
            }
        }

    }

    private void SpawnCoin()
    {
        Debug.Log("Spawning Coin");
        Instantiate(coinPrefab, spawnPoint.position, Quaternion.identity);
    }
}
