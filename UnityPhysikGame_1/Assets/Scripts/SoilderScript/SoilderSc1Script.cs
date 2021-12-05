using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoilderSc1Script : MonoBehaviour
{
    private float Speed = 0.12f;
    private MainProgrScript ProgManScr;
    private Animator animat;
 
    void Start()
    {
        ProgManScr = FindObjectOfType<MainProgrScript>();
        animat =  GetComponent<Animator>();
    }

    void Update()
    {
        Move("Run", Speed, animat);
    }
    public void Move(string move, float Sped, Animator anim)
    {
            // бег персонажа в начале 1ой сцены + активация анимации бега
            transform.Translate(Vector3.forward * Sped * Time.deltaTime);

            if (Sped != 0)
            
                anim.SetBool(move, true);
            else
                anim.SetBool(move, false);

    }
    void OnCollisionEnter(Collision other)
    {
        // при столкновении с невидим. объектом остановиться персонажу
        // появление условия 1ой задачи
        if (other.gameObject.CompareTag("GameController"))
        {
            Speed = 0;
            Destroy(other.gameObject);
            ProgManScr.ConditZadach1.SetActive(true);
            ProgManScr.ButtnSpeed1.SetActive(true);
            ProgManScr.InputFieldSpeed1.SetActive(true);
        }
      
    }
   
}
