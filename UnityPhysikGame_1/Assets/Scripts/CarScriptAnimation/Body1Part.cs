using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Body1Part : MonoBehaviour
{
    public Animator animat;
    public bool IsBreak = false;

    void Start()
    {
        animat = GetComponent<Animator>();
    }

    void Update()
    {
        AnimBreak(IsBreak, animat, "ij");
    }

    public void AnimBreak(bool b, Animator anim, string str)
    {
        // активация анимации поломки машины
       if (b == true)

            anim.SetBool(str, true);
        else
            anim.SetBool(str, false);
    }

}
