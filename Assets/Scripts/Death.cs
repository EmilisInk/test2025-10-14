using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public AudioSource deathSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            deathSound.Play();
            ScoreBoard.instance.DecreaseHealth(1);
            Destroy(gameObject);
        }
    }
}
