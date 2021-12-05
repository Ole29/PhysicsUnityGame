using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel1 : MonoBehaviour
{
    private Animator animatr;
    private Wheel0 wheel0;
    public bool IsGoto = false;

    void Start()
    {
        animatr = GetComponent<Animator>();
        wheel0 = FindObjectOfType<Wheel0>();
    }

    void Update()
    {
        // активация анимации движения колес
        wheel0.Date("go", IsGoto, animatr);
    }

}
