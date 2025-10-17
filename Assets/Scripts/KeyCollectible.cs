using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollectible : MonoBehaviour
{
    public GameObject toDestroy;
    public GameObject toDestroy2;
    public GameObject targetObject;
    public GameObject prefab;
    public AudioSource collectedSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collectedSound.Play();
            Destroy(gameObject);
            Destroy(toDestroy);
            Destroy(toDestroy2);
            Vector3 pos = targetObject.transform.position;
            Quaternion rot = targetObject.transform.rotation;
            Destroy(targetObject);
            Instantiate(prefab, pos, rot);
        }
    }
}
