using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel0 : MonoBehaviour
{
    private Animator animat;
    public bool IsGo = false;
    void Start()
    {
        animat = GetComponent<Animator>();
    }

    void Update()
    {
        Date("went", IsGo, animat);
    }

    public void Date(string go, bool IsGo, Animator anim)
    {
        // активация анимации движения колес
        if (IsGo == true)
        {
            anim.SetBool(go, true);
        }
        else
        {
            anim.SetBool(go, false);
        }
    }

}
