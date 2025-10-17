using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public AudioSource collectedSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collectedSound.Play();
            ScoreBoard.instance.IncreaseHealth(1);
            Destroy(gameObject);
        }
    }
}
