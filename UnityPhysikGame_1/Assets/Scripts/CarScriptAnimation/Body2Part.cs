using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body2Part : MonoBehaviour
{
    public Animator animat;
    public bool IsBreak2 = false;
    private Body1Part body;
    void Start()
    {
        animat = GetComponent<Animator>();
        body = FindObjectOfType<Body1Part>();
    }

    void Update()
    {
        // активация анимации поломки машины
        body.AnimBreak(IsBreak2, animat, "State2");
    }

}
