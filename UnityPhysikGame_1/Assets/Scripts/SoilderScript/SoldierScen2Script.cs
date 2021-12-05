using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoldierScen2Script : MonoBehaviour
{
    private float Speed = 0.01f;
    private Animator animat;
    private SoilderSc1Script soilderSc1;

    void Start()
    {
        soilderSc1 = FindObjectOfType<SoilderSc1Script>();
        animat = GetComponent<Animator>();
        animat.SetBool("Help", true);
    }

    void Update()
    {
        // активация бега персонажа и активация анимации
        soilderSc1.Move("Help", Speed, animat);
    }
   

    void OnCollisionEnter(Collision other)
    {
        // при столкновении с машиной остановиться
        if (other.gameObject.CompareTag("Pick")) {

            Speed = 0;
        }
       
    }

}