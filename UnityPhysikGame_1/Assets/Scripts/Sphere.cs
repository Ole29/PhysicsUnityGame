using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    //Дано: начальная скорость, угол, под которым бросают объект
    //Определить: высоту максимальную, на которую поднимется объект
    // расстояние, на которое упадет объект
    float t;
    float Vz;
    float Vy;
    float Angle = 30f;
    Vector3 NextPosition;
    public float Speed = 5f; 
    public float Gravity = 9.8f;

    void Start()
    {
        if (gameObject.name.Equals("Sphere3SmalL"))
        {
            Speed = 5f;
            Debug.Log("Sphere3Small");
        }
        else if (gameObject.name.Equals("Sphere"))
        {
            Speed = 10f;
            Debug.Log("Spheree");
        }
        else if (gameObject.name.Equals("Sphere3Bigg"))
        {
            Speed = 20f;
            Debug.Log("Sphere3Bigg");
        }

        transform.localEulerAngles = new Vector3(transform.parent.eulerAngles.x, 0, transform.parent.eulerAngles.z);
        transform.parent.eulerAngles = new Vector3(0, transform.parent.eulerAngles.y, 0);
        Angle = -transform.localEulerAngles.x;
        Angle = Angle * Mathf.Deg2Rad; //перевод угла в радиан
    }

    void Update()
    {
        ret();
    }
     void ret() {
       
         t += Time.deltaTime;
         Vz =  Speed * t * Mathf.Cos(Angle) * Time.deltaTime;
         Vy = Speed * t * Mathf.Sin(Angle) * Time.deltaTime - Gravity * (t * t) / 2 * Time.deltaTime;
         NextPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + Vy, transform.localPosition.z + Vz);

        // поворот патрон под заданным углом
        transform.rotation = Quaternion.LookRotation(transform.localPosition - NextPosition);
        transform.eulerAngles += new Vector3(0, transform.parent.eulerAngles.y, 0);
        transform.localPosition = NextPosition;
    }

}
 