using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyClient : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("collision?");
            Destroy(collision.gameObject);
        }
    }
}
