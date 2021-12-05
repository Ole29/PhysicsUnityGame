using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletFalling : MonoBehaviour
{
    private float SpeedM = 0;
    private Rigidbody Bullet;

    void Start()
    { 
        Bullet = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // замедленное падение снаряда в 1ой задаче (просто вниз)
        if (Bullet.velocity.magnitude > SpeedM)
        {
            Bullet.velocity = Vector3.ClampMagnitude(Bullet.velocity, SpeedM);
        }
    }

}


