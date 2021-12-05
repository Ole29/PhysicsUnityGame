using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoldierScene3Scr : MonoBehaviour
{
    private Animator animat;

    void Start()
    {
        animat = GetComponent<Animator>();
    }

    void Update()
    {
        Apeear();
    }
    public void Apeear()
    {
        // активация анимации поворота персонажа
        animat.SetBool("IfPovorot", false);
        Invoke("Povorot", 11f);
    }

    void Povorot()
    {
        animat.SetBool("IfPovorot", true);
    }
}
