using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int score = 0;
    public AudioClip collectedClip;
    public float volume = 1f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collectedClip != null)
            {
                AudioSource.PlayClipAtPoint(collectedClip, transform.position, volume);
            }
            ScoreBoard.instance.AddScore(1);
            Destroy(gameObject);
        }
    }
}
