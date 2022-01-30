using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundery : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Exit Collider");

        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
        }
    }
}