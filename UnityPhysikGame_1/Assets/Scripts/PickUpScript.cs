using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PickUpScript : MonoBehaviour
{
    private MainProgrScript ScriptProgMan;
    private Body1Part Bod1;
    private Body2Part Bod2;
    private Wheel0 Wheel_0;
    private Wheel1 Wheel_1;
    private bool Bullet = true;
    private float SpeedCar;
    private int Count;

    void Start()
    {
        // подключение скриптов, поля и методы которых будут использоваться в классе
        ScriptProgMan = FindObjectOfType<MainProgrScript>();
        Bod1 = FindObjectOfType<Body1Part>();
        Bod2 = FindObjectOfType<Body2Part>();
        Wheel_0 = FindObjectOfType<Wheel0>();
        Wheel_1 = FindObjectOfType<Wheel1>();
        SpeedCar = 0;
    }

    void Update()
    {
         Movee();       
    }
    void Movee() {   

        // движение машины с заданной скоростью
        transform.Translate(Vector3.forward * SpeedCar * Time.deltaTime);
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player")) {

            // если снаряд попал в машину
            if (Bullet) {
                // активация сообщений для перехода ко 2ой сцене
                Invoke("SetActWinnMessag", 1f);
                Invoke("SetActEssencMessag", 2.5f);
                Invoke("ActivAnimationCar", 4.5f);
                Invoke("ActivBreakMessage", 7f);
                Bullet = false;
            }
        }

        if (other.gameObject.CompareTag("HelpSoild")) {

            // появление персонажей для 3ей сцены
            ScriptProgMan.Panelground2 = (GameObject)Instantiate(ScriptProgMan.Panelground2, ScriptProgMan.Panelground2.transform.position, ScriptProgMan.Panelground2.transform.rotation);
            ScriptProgMan.Panelground2.GetComponent<RectTransform>().position = new Vector3(ScriptProgMan.Mountain.transform.position.x - 0.08f, ScriptProgMan.Mountain.transform.position.y - 0.024f, ScriptProgMan.Soild.transform.position.z - 1.8f);
            ScriptProgMan.SoldierShotScene3 = (GameObject)Instantiate(ScriptProgMan.SoldierShotScene3, ScriptProgMan.SoldierShotScene3.transform.position, ScriptProgMan.SoldierShotScene3.transform.rotation);
            ScriptProgMan.SoldierShotScene3.GetComponent<RectTransform>().position = new Vector3(ScriptProgMan.Mountain.transform.position.x - 0.28f, ScriptProgMan.Mountain.transform.position.y + 0.12f, ScriptProgMan.Soild.transform.position.z - 3.45f);
            DestroyDuplicat(ScriptProgMan.SoldierShotScene3);

            SpeedCar = 0.5f;
            // активация анимации движения колес машины
            Wheel_0.IsGo = true;
            Wheel_1.IsGoto = true;
            Invoke("GoToo", 4.5f);
        }

        if (other.gameObject.CompareTag("Solid11")) {

            // в случае, если введенная сила меньше верной,  машина не двигается с места
            SpeedCar = 0f;
            Invoke("Break", 1.5f);
        }

        if (other.gameObject.CompareTag("Solid22")) {

            // в случае, если введенная сила превышает минимальную верную,  машина очень быстро уезжает
            ScriptProgMan.Panelground2 = (GameObject)Instantiate(ScriptProgMan.Panelground2, ScriptProgMan.Panelground2.transform.position, ScriptProgMan.Panelground2.transform.rotation);
            ScriptProgMan.Panelground2.GetComponent<RectTransform>().position = new Vector3(ScriptProgMan.Mountain.transform.position.x - 0.08f, ScriptProgMan.Mountain.transform.position.y - 0.024f, ScriptProgMan.Soild.transform.position.z - 1.8f);
            DestroyDuplicat(ScriptProgMan.SoldierShotScene3);

            SpeedCar = 1.2f;
            // активация анимации движения колес машины
            Wheel_0.IsGo = true;
            Wheel_1.IsGoto = true;
            Destroy(ScriptProgMan.BulletCopy);
        }

        if (other.gameObject.CompareTag("BulletNew")) {

            // если скорость больше верной (в 1ой задаче), уничтожение машины
            ScriptProgMan.Crystal = (GameObject)Instantiate(ScriptProgMan.Crystal, ScriptProgMan.Crystal.transform.position, ScriptProgMan.Crystal.transform.rotation);
            ScriptProgMan.Crystal.GetComponent<RectTransform>().position = new Vector3(ScriptProgMan.Mountain.transform.position.x, ScriptProgMan.Mountain.transform.position.y + 0.15f, ScriptProgMan.Mountain.transform.position.z - 0.72f);
            DestroyDuplicat(ScriptProgMan.Crystal);
            Destroy(other.gameObject, 1.5f);

            // сокрытие интерфейса 1ой задачи
            ScriptProgMan.ButtnSpeed1.SetActive(false);
            ScriptProgMan.ConditZadach1.SetActive(false);
            ScriptProgMan.InputFieldSpeed1.SetActive(false);
            ScriptProgMan.GameOver.SetActive(true);
            ScriptProgMan.ReplayButtnSc1.SetActive(true);
        }
        if (other.gameObject.CompareTag("Bullet3Scene")) {

            // в 3ей сцене появление снаряда в машине и сразу движение к 3ей задаче
            SpeedCar = 0.5f;
            transform.Translate(Vector3.forward * SpeedCar * Time.deltaTime);
            Moving();
        }
    }


    private void DestroyDuplicat(GameObject obj) {

        // удаление дубликатов объектов
        Count++;
        if (Count > 1) {

            Destroy(obj);
            Count = 0;
        }
    }

    void SetActWinnMessag() {

        ScriptProgMan.WinMessag.SetActive(true);
    }
    void SetActEssencMessag() {

        ScriptProgMan.WinMessag.SetActive(false);
        ScriptProgMan.EssencialMessage.SetActive(true);
    }
    void ActivAnimationCar() {

        ScriptProgMan.EssencialMessage.SetActive(false);
        Bod1.IsBreak = true;
        Bod2.IsBreak2 = true;
    }
    void ActivBreakMessage() {

        ScriptProgMan.BreakMessage.SetActive(true);
    }

    void GoToo() {

        SpeedCar = 0;

        // появление условия 3ей задачи
        ScriptProgMan.ConditZadach3.SetActive(true);
        ScriptProgMan.InputLength3.SetActive(true);
        ScriptProgMan.ButtonLength3.SetActive(true);
        ScriptProgMan.InputHeight3.SetActive(true);

        // появление локации и персонажа для 3ей задачи 
        ScriptProgMan.PanelGround3 = Instantiate(ScriptProgMan.PanelGround3, ScriptProgMan.PanelGround3.transform.position, ScriptProgMan.PanelGround3.transform.rotation);
        ScriptProgMan.PanelGround3.GetComponent<RectTransform>().position = new Vector3(ScriptProgMan.Mountain.transform.position.x - 0.08f, ScriptProgMan.Mountain.transform.position.y - 0.08f, ScriptProgMan.Soild.transform.position.z - 6.5f);
        ScriptProgMan.SoildCatchBull = Instantiate(ScriptProgMan.SoildCatchBull, ScriptProgMan.SoildCatchBull.transform.position, ScriptProgMan.SoildCatchBull.transform.rotation);
        ScriptProgMan.SoildCatchBull.GetComponent<RectTransform>().position = new Vector3(ScriptProgMan.Mountain.transform.position.x - 0.32f, ScriptProgMan.Mountain.transform.position.y - 0.02f, ScriptProgMan.Soild.transform.position.z - 6.55f);
        DestroyDuplicat(ScriptProgMan.SoildCatchBull);
    }

    void Moving() {

        Wheel_0.IsGo = true;
        Wheel_1.IsGoto = true;
        ScriptProgMan.Panelground2 = (GameObject)Instantiate(ScriptProgMan.Panelground2, ScriptProgMan.Panelground2.transform.position, ScriptProgMan.Panelground2.transform.rotation);
        ScriptProgMan.Panelground2.GetComponent<RectTransform>().position = new Vector3(ScriptProgMan.Mountain.transform.position.x - 0.08f, ScriptProgMan.Mountain.transform.position.y - 0.08f, ScriptProgMan.Soild.transform.position.z - 1.9f);
        ScriptProgMan.SoldierShotScene3 = (GameObject)Instantiate(ScriptProgMan.SoldierShotScene3, ScriptProgMan.SoldierShotScene3.transform.position, ScriptProgMan.SoldierShotScene3.transform.rotation);
        ScriptProgMan.SoldierShotScene3.GetComponent<RectTransform>().position = new Vector3(ScriptProgMan.Mountain.transform.position.x - 0.28f, ScriptProgMan.Mountain.transform.position.y + 0.12f, ScriptProgMan.Soild.transform.position.z - 3.6f);
        DestroyDuplicat(ScriptProgMan.SoldierShotScene3);

        Invoke("GoToo", 3.5f);
    }
    
}
    
