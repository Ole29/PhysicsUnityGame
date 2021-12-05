using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;



public class InputZadach1 : MonoBehaviour
{
    private MainProgrScript MainProgrScr;
    public GameObject InputFieldSped;

    // входные значения для нахождения начальной  скорости
    private double g = 9.8;
    private double SpeedMax = 15;
    private double height = 20;
    private int SpeedMaxDano;
    private double Height;
    private Button ButSpeed1;

    // сообщения на случай некорректного ввода
    public GameObject NotInputSped;
    public GameObject InCorrectInput;

    // переменные для считывания введенного значения скорости
    public Text textSpeed;
    public string StringSpeed;
    private GameObject FielObject;
    private InputField Flield;
    private string ForceString;
    public Text SpeedCorrect;
    public string CorrectSpeed;
    private double SpeedRight;
    private int SpeedInput;
    private int Count;

    // переменные для вывода значений макс. скорости и высоты в условие задачи
    public Text textHeight;
    public Text textMaxSpeed;

    private void Start()
    {
        MainProgrScr = FindObjectOfType<MainProgrScript>();

        // формула расчета скорости снаряда (в 1ой задаче)
        SpeedRight = Convert.ToInt32(Math.Sqrt(Math.Abs(Math.Pow(SpeedMax, 2) - 2 * g * height)));

        // вывод значения высоты в условие пользователльского интерфейса
        Height = Convert.ToInt32(height);
        textHeight.text = Height.ToString();

        // вывод значения макс. скорости в условие
        SpeedMaxDano = Convert.ToInt32(SpeedMax);
        textMaxSpeed.text = SpeedMaxDano.ToString();

        ButSpeed1 = GetComponent<Button>();
        ButSpeed1.onClick.AddListener(UpdaButtonSpeed);

        // поле ввода значения скорости снаряда
        FielObject = GameObject.Find("InputFieldSpeed1");
        Flield = FielObject.GetComponent<InputField>();

        NotInputSped.SetActive(false);
        InCorrectInput.SetActive(false);
    }

  
    private void UpdaButtonSpeed()
    {
        ForceString = Flield.text;

        // проверяем, пустое ли поле ввода
        if (ForceString == "") {

            // если пустое, активируем соответствующие сообщения для пользователя
            InCorrectInput.SetActive(false);
            NotInputSped.SetActive(true);
            if (NotInputSped != null) {

                textSpeed.text = StringSpeed;
            }  
        }
        else
        {
            // если поле ввода не пустое, пытаемся преобразовать введенное значение в целое
            if (Int32.TryParse(ForceString, out SpeedInput)) {

              NotInputSped.SetActive(false);
              InCorrectInput.SetActive(false);
              SpeedInput = Int32.Parse(ForceString);

                //проверяем, не отрицательно ли введенное значение 
                if (SpeedInput <= 0) {

                    InCorrectInput.SetActive(true);
                    if (InCorrectInput != null) {

                        SpeedCorrect.text = CorrectSpeed;
                    }
                }
                else
                {
                     // если введенное значение скорости больше верного
                     if (SpeedInput > SpeedRight) {

                         MainProgrScr.BulletBigSpeed = (GameObject)Instantiate(MainProgrScr.BulletBigSpeed, MainProgrScr.BulletBigSpeed.transform.position, MainProgrScr.BulletBigSpeed.transform.rotation);
                         MainProgrScr.BulletBigSpeed.GetComponent<RectTransform>().position = new Vector3(MainProgrScr.Mountain.transform.position.x - 0.08f, MainProgrScr.Soild.transform.position.y + 0.1f, MainProgrScr.Mountain.transform.position.z - 0.5f);

                         DestroyDuplicates(MainProgrScr.BulletBigSpeed);
                         MainProgrScr.TooMaxSpeed.SetActive(true);
                     }

                      // если введенное значение скорости равно верному, снаряд приземляется прямо в кузов машины
                     else if (SpeedInput == SpeedRight) {

                         MainProgrScr.BulletCopy = (GameObject)Instantiate(MainProgrScr.Bullet, MainProgrScr.Bullet.transform.position, MainProgrScr.Bullet.transform.rotation);
                         MainProgrScr.BulletCopy.GetComponent<RectTransform>().position = new Vector3(MainProgrScr.Mountain.transform.position.x - 0.08f, MainProgrScr.Soild.transform.position.y + 0.1f, MainProgrScr.Mountain.transform.position.z - 0.49f);//y + 0.15   z - 0.5

                         DestroyDuplicates(MainProgrScr.BulletCopy);
                         MainProgrScr.InputFieldSpeed1.SetActive(false);
                         MainProgrScr.ConditZadach1.SetActive(false);
                         MainProgrScr.ButtnSpeed1.SetActive(false);
                         NotInputSped.SetActive(false);
                     }
                     else {
                         // если введенное значение скорости меньше верного, снаряд исчезает в воздухе
                         MainProgrScr.DestroyBullet = Instantiate(MainProgrScr.DestroyBullet, MainProgrScr.DestroyBullet.transform.position, MainProgrScr.DestroyBullet.transform.rotation);
                         MainProgrScr.DestroyBullet.GetComponent<RectTransform>().position = new Vector3(MainProgrScr.Mountain.transform.position.x , MainProgrScr.Mountain.transform.position.y + 0.4f, MainProgrScr.Mountain.transform.position.z - 0.5f);//z - 0.9

                         MainProgrScr.BulletCopy = (GameObject)Instantiate(MainProgrScr.Bullet, MainProgrScr.Bullet.transform.position, MainProgrScr.Bullet.transform.rotation);
                         MainProgrScr.BulletCopy.GetComponent<RectTransform>().position = new Vector3(MainProgrScr.Mountain.transform.position.x - 0.08f, MainProgrScr.Soild.transform.position.y + 0.1f, MainProgrScr.Mountain.transform.position.z - 0.5f);

                         DestroyDuplicates(MainProgrScr.BulletCopy);
                         MainProgrScr.ConditZadach1.SetActive(false);
                         MainProgrScr.ButtnSpeed1.SetActive(false);
                         MainProgrScr.InputFieldSpeed1.SetActive(false);
                         NotInputSped.SetActive(false);
                         MainProgrScr.ReplayButtnSc1.SetActive(true);
                         MainProgrScr.GameOver.SetActive(true);
                         MainProgrScr.TooMinSpeed.SetActive(true);    
                     }   
                        
                }
             
            }
            else {
                // если введено неккоректное значение, вывести сообщение
                NotInputSped.SetActive(false);
                InCorrectInput.SetActive(true);
                if (InCorrectInput != null) {

                    SpeedCorrect.text = CorrectSpeed;
                }
            }
        }
    }

    private void DestroyDuplicates(GameObject obj) {
    // удаление дубликатов объектов
        Count++;
        if (Count > 1) {

            Destroy(obj);
            Count = 0;
        }
    }

}
