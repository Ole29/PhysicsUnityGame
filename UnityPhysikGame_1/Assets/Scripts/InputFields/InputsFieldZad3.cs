using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;



public class InputsFieldZad3 : MonoBehaviour
{
  
    private Button button;
    private MainProgrScript ProgManScr;

    // переменные для считывания введенного значения скорости
    private GameObject FielObjectHeig;
    private InputField FlieldHeight;
    private string HieghtString;
    private GameObject FielObject;
    private InputField Flield;
    private string ForceString;
    private int Lenght;
    private int HeightH;

    // переменные для вывода значений скорости и угла в условие задачи
    public Text textSpeed3;
    public Text textAngle;
    private int Speed;
    private int Ang;

    // входные значения для расчета высоты и расстояния
    private float Speed3 = 10.0f;
    private float Angle = 30.0f;
    private float Gravity = 9.8f;
    private int H;
    private int L;
 
    private int Count;
    public GameObject NotInputSped;		    //сообщение «скорость не введена»
    public GameObject InCorrectInput;       //сообщение «некорректный ввод»	


    public void Start()
    {

        ProgManScr = FindObjectOfType<MainProgrScript>();
       
        button = GetComponent<Button>();
        button.onClick.AddListener(UpdLengthHeight);

        // формула расчета высоты и дальности полета снаряда (в 3ей задаче)
        L = Convert.ToInt32(Math.Abs((Speed3 * Speed3 * Mathf.Sin(2 * Angle)) / Gravity));
        H = Convert.ToInt32((Speed3 * Speed3 * Mathf.Sin(Angle) * Mathf.Sin(Angle)) / (2 * Gravity));

        // вывод исходных значений в условие пользователльского интерфейса
        Speed = Convert.ToInt32(Speed3);
        Ang = Convert.ToInt32(Angle);
        textSpeed3.text = Speed.ToString();
        textAngle.text = Ang.ToString();

        // поле ввода расстояния 
        FielObject = GameObject.Find("InputFieldLength3");
        Flield = FielObject.GetComponent<InputField>();

        // поле ввода высоты
        FielObjectHeig = GameObject.Find("InputFieldHeight");
        FlieldHeight = FielObjectHeig.GetComponent<InputField>();

    }

    // Update is called once per frame
    public void UpdLengthHeight()
    {
       
        ForceString = Flield.text;
        HieghtString = FlieldHeight.text;

        // проверяем, пустое ли поле ввода
        if (ForceString == ""|| HieghtString == "")
        {
            // если пустое, активируем соответствующие сообщения для пользователя
            InCorrectInput.SetActive(false);        
            NotInputSped.SetActive(true);
        }
       
        else
        {
            // если поле ввода не пустое, пытаемся преобразовать введенные значения в целое
            if (Int32.TryParse(ForceString, out Lenght) && Int32.TryParse(HieghtString, out HeightH))
            {
                InCorrectInput.SetActive(false);        
                NotInputSped.SetActive(false);
                Lenght = Int32.Parse(ForceString);
                HeightH = Int32.Parse(HieghtString);

                //проверяем, не отрицательны ли введенные значения 
                if (Lenght <= 0 && HeightH <= 0)
                {
                    ProgManScr.WRONG.SetActive(true);
                }
                else
                {
                    // р/м случаи, когда введенные значения расстояния и высоты не совпадают с верными значениями 
                    if (Lenght > L || HeightH > H)
                    {
                        if (Lenght > L && HeightH == H)
                        {
                            InCorrectInput.SetActive(false);        //вывод «пустаястрока»
                            NotInputSped.SetActive(false);
                            Invoke("BigLengt", 1.5f);
                            Bigg();
                        }
                        else
                        if (Lenght == L && HeightH > H)
                        {
                            InCorrectInput.SetActive(false);        //вывод «пустаястрока»
                            NotInputSped.SetActive(false);
                            Invoke("BigHeught", 1.5f);
                            Bigg();

                        }
                        else
                        {
                            InCorrectInput.SetActive(false);        
                            NotInputSped.SetActive(false);
                            UnActive();
                            ProgManScr.WRONG.SetActive(true);
                            ProgManScr.GameOver.SetActive(true);
                            Invoke("Again", 1.5f);
                        }

                    }

                    else if (Lenght == L && HeightH == H) {

                        // значения расстояния и высоты, введенные пользователем верны
                        ProgManScr.ReplMenuAgain.SetActive(false);
                        InCorrectInput.SetActive(false);        
                        NotInputSped.SetActive(false);
                        UnActive();

                        // появляется снаряд, долетающий до персонажа
                        ProgManScr.Spere = Instantiate(ProgManScr.Spere, ProgManScr.Spere.transform.position, ProgManScr.Spere.transform.rotation);
                        ProgManScr.Spere.GetComponent<RectTransform>().position = new Vector3(ProgManScr.Mountain.transform.position.x - 0.25f, ProgManScr.Mountain.transform.position.y + 0.6f, ProgManScr.Mountain.transform.position.z - 4.05f);//x - 0.25

                        DestoyDuplicat(ProgManScr.Spere);
                        Invoke("Destr", 2.7f);

                    }
                    else {

                    // р/м случаи, когда введенные значения расстояния и высоты не совпадают с верными значениями 
                        if (Lenght < L || HeightH < H) {

                            if (Lenght < L && HeightH == H) {

                                InCorrectInput.SetActive(false);        
                                NotInputSped.SetActive(false);
                                ProgManScr.LittleLengt.SetActive(true);
                                Little();
                            }
                            else if (Lenght == L && HeightH < H) {

                                InCorrectInput.SetActive(false);       
                                NotInputSped.SetActive(false);
                                ProgManScr.LittleHeught.SetActive(true);
                                Little();
                            }
                            else {
                             
                                InCorrectInput.SetActive(false);        
                                NotInputSped.SetActive(false);
                                UnActive();
                                ProgManScr.WRONG.SetActive(true);
                                ProgManScr.GameOver.SetActive(true);
                                Invoke("Again", 1.5f);
                            }

                        }

                    }
                }
               
            }
            else
            {
                // введены некорректные значения
                InCorrectInput.SetActive(true);        
                NotInputSped.SetActive(false);
            }
        }

    }

    public void DestoyDuplicat(GameObject obj) {
        // удаление дубликатов объектов

        Count++;
        if (Count > 1)
        {
            Destroy(obj);
            Count = 0;
        }
    }
    void BigHeught() {

        ProgManScr.BigHeught.SetActive(true);
    }

   public void BigLengt() {
        
        ProgManScr.BigLengt.SetActive(true);
    }
    void Destr() {

        // появление пойманного снаряда и сообщение о победе
        ProgManScr.CatchSphere3 = Instantiate(ProgManScr.CatchSphere3, ProgManScr.CatchSphere3.transform.position, ProgManScr.CatchSphere3.transform.rotation);
        ProgManScr.CatchSphere3.GetComponent<RectTransform>().position = new Vector3(ProgManScr.Mountain.transform.position.x - 0.38f, ProgManScr.Mountain.transform.position.y + 0.72f, ProgManScr.Mountain.transform.position.z - 6.7f);
        ProgManScr.WinMessag.SetActive(true);
        Invoke("AgainMenu", 2f);
    }

    void Again() {

        // активируем кнопку перезапуска 3ей сцены
        ProgManScr.ReplayScene3.SetActive(true);
    }
    void AgainMenu() {

        ProgManScr.WinMessag.SetActive(false);
        ProgManScr.ReplMenu.SetActive(true);
    }
    void Bigg() {

        UnActive();

        ProgManScr.Sphere3Bigg = Instantiate(ProgManScr.Sphere3Bigg, ProgManScr.Sphere3Bigg.transform.position, ProgManScr.Sphere3Bigg.transform.rotation);
        ProgManScr.Sphere3Bigg.GetComponent<RectTransform>().position = new Vector3(ProgManScr.Mountain.transform.position.x - 0.15f, ProgManScr.Mountain.transform.position.y + 0.6f, ProgManScr.Mountain.transform.position.z - 4.05f);

        DestoyDuplicat(ProgManScr.Sphere3Bigg);
        ProgManScr.GameOver.SetActive(true);
        Invoke("Again", 2f);
    }
    void Little() {

        UnActive();
        ProgManScr.Sphere3SmalL = Instantiate(ProgManScr.Sphere3SmalL, ProgManScr.Sphere3SmalL.transform.position, ProgManScr.Sphere3SmalL.transform.rotation);
        ProgManScr.Sphere3SmalL.GetComponent<RectTransform>().position = new Vector3(ProgManScr.Mountain.transform.position.x - 0.15f, ProgManScr.Mountain.transform.position.y + 0.6f, ProgManScr.Mountain.transform.position.z - 4.05f);                                                                                                                                                                                                                        //разница между Mountain и Soild по z = 0,4f
        DestoyDuplicat(ProgManScr.Sphere3SmalL);
        ProgManScr.GameOver.SetActive(true);
        Invoke("Again", 2f);
    }
    void UnActive() {

        // сокрытие интерфейса  3ей задачи
        ProgManScr.ConditZadach3.SetActive(false);
        ProgManScr.InputLength3.SetActive(false);
        ProgManScr.ButtonLength3.SetActive(false);
        ProgManScr.InputHeight3.SetActive(false);
    }
}
