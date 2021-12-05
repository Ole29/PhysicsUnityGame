using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchBull : MonoBehaviour
{
     void Update()
    {
        Invoke("Destroy", 2.15f);
    }
    void Destroy()
    {
        // удаление снаряда в 3ей задаче
        Destroy(transform.GetChild(0).gameObject);
    }
}
