using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class InputZadach2 : MonoBehaviour
{
    private Button ButVVodForc;

    // входные значения для нахождения силы
    public int RightForce = 0;
    private int M = 500;
    private int m = 2;
    private double g = 9.8f;
    private float y = 0.15f;

    private MainProgrScript ScriptProgMan;
    private GameObject FielObject;
    public GameObject WrongInput;
    private InputField Field;

    // переменные для считывания введенного значения
    private string ForceString;
    private int InputForce;

    // переменные для вывода значений в условие задачи
    public Text textMass;
    public Text textYek;   		
    
    public Text textForce;
    public string StringForce;
    public Text ForceCorrect;
    public string CorrectForce;


    private void Start()
    {
        ScriptProgMan = FindObjectOfType<MainProgrScript>();
        ButVVodForc = GetComponent<Button>();
        ButVVodForc.onClick.AddListener(VVodForce);
        WrongInput.SetActive(false);

        // формула расчета силы во 2ой задаче
        RightForce = Convert.ToInt32((M+m) * g * y);

        // получение компонентов поля ввода
        FielObject = GameObject.Find("InputForce2");
        Field = FielObject.GetComponent<InputField>();

        // вывод значений в пользовательский интерфейс
        textMass.text = M.ToString();
        textYek.text = m.ToString();
    }


    private void VVodForce()
    {
        ForceString = Field.text;
        // если поле ввода скорости пустое
        if (ForceString == "") {
            WrongInput.SetActive(false);        
            ScriptProgMan.NotInputForce.SetActive(true);
        }
        else {

            //иначе считываем введенное значение
            if (Int32.TryParse(ForceString, out InputForce)) {

                InputForce = Int32.Parse(ForceString);

                // если введено правильное значение, продолжаем игру
                if (InputForce == RightForce) {

                    ScriptProgMan.NotInputForce.SetActive(false);
                    WrongInput.SetActive(false);
                    ScriptProgMan.WinMessag.SetActive(true);
                    ActiveCondition();
                    Invoke("ContinueGame", 1.5f);
                }
                else {

                    // если введенное значение меньше верного, машина не двигается
                    if (InputForce < RightForce) {

                        ScriptProgMan.NotInputForce.SetActive(false);
                        WrongInput.SetActive(false);
                        ActiveCondition();
                        Invoke("SmallForc", 0.5f);

                        ScriptProgMan.NotForceSmall.SetActive(true);
                        ScriptProgMan.ReplayScene2.SetActive(true);
                        ScriptProgMan.GameOver.SetActive(true);
                    }
                    else {
                        // если введенное значение больше верного, машина уезжает далеко
                        ScriptProgMan.NotInputForce.SetActive(false);
                        WrongInput.SetActive(false);
                        ActiveCondition();
                        ScriptProgMan.GameOver.SetActive(true);
                        ScriptProgMan.NotForceBig.SetActive(true);
                        Invoke("BigForc", 0.5f);
                    }
                }
            }
            else {
                // введены некорректные символы
                ScriptProgMan.NotInputForce.SetActive(false);
                WrongInput.SetActive(true);
            }
        }
    }


    private void DestroySoilder(GameObject soild) {

        // удаление дубликатов объектов
        int Count = 0;
        Count++;
        if (Count > 1) {

            Destroy(soild);
            Count = 0;
        }
    }

    private void ActiveCondition() {

        // сокрытие интерфейса 2ой задачи
        ScriptProgMan.ConditZadach2.SetActive(false);
        ScriptProgMan.InputForce2.SetActive(false);
        ScriptProgMan.ButtnForce2.SetActive(false);
    }

    private void ContinueGame() {

        ScriptProgMan.WinMessag.SetActive(false);
        ScriptProgMan.SoldierScene2 = (GameObject)Instantiate(ScriptProgMan.SoldierScene2, ScriptProgMan.SoldierScene2.transform.position, ScriptProgMan.SoldierScene2.transform.rotation);
        ScriptProgMan.SoldierScene2.GetComponent<RectTransform>().position = new Vector3(ScriptProgMan.Mountain.transform.position.x - 0.39f, ScriptProgMan.Mountain.transform.position.y + 0.22f, ScriptProgMan.Soild.transform.position.z + 0.52f);
        DestroySoilder(ScriptProgMan.SoldierScene2);
    }

    private void SmallForc() {

        ScriptProgMan.WinMessag.SetActive(false);
        ScriptProgMan.Soldier2SmalForc = (GameObject)Instantiate(ScriptProgMan.Soldier2SmalForc, ScriptProgMan.Soldier2SmalForc.transform.position, ScriptProgMan.Soldier2SmalForc.transform.rotation);
        ScriptProgMan.Soldier2SmalForc.GetComponent<RectTransform>().position = new Vector3(ScriptProgMan.Mountain.transform.position.x - 0.39f, ScriptProgMan.Mountain.transform.position.y + 0.22f, ScriptProgMan.Soild.transform.position.z + 0.52f);
        DestroySoilder(ScriptProgMan.Soldier2SmalForc);
    }
   private void BigForc() {

        ScriptProgMan.WinMessag.SetActive(false);
        ScriptProgMan.Soldier2BigForc = (GameObject)Instantiate(ScriptProgMan.Soldier2BigForc, ScriptProgMan.Soldier2BigForc.transform.position, ScriptProgMan.Soldier2BigForc.transform.rotation);
        ScriptProgMan.Soldier2BigForc.GetComponent<RectTransform>().position = new Vector3(ScriptProgMan.Mountain.transform.position.x - 0.38f, ScriptProgMan.Mountain.transform.position.y + 0.22f, ScriptProgMan.Soild.transform.position.z + 0.52f);
        DestroySoilder(ScriptProgMan.Soldier2BigForc);
        ScriptProgMan.ReplayScene2.SetActive(true);
    }

}
