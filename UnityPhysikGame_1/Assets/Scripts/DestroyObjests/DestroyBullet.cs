using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        // удаление снаряда 
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }

    }
}