using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPickUp : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    { 
            // удаление машины
            if (other.gameObject.CompareTag("Pick"))
            {
                Destroy(other.gameObject, 0.5f);
            }
    }

}
