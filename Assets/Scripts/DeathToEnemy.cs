using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class DeathToEnemy : MonoBehaviour
{
    public Transform start;
    public Transform end;
    public float speed = 2f;
    public AudioSource boom;

    private Transform target;
    private void Start()
    {
        target = end;
        transform.position = start.position;

    }

    private void Update()
    {
        transform.Rotate(0f, 0f, 100f * Time.deltaTime);
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            if (target == end)
            {
                target = start;
            }
            else
            {
                target = end;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.CompareTag("Player"))
        {
            ScoreBoard.instance.DecreaseHealth(1);
            boom.Play();
        }
    }
}
