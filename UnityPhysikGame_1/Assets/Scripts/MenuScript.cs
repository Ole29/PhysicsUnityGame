using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void ScenQuit()
    {
        // выход из приложения
        Application.Quit();
    }
    public  void LoadMenu()
    {
        // загрузка меню
        SceneManager.LoadScene("Menu");
    }

    public void LoadScen1()
    {
        // загрузка 1ой задачи
        SceneManager.LoadScene("Zadacha11");
    }
    public void LoadScen2()
    {
        SceneManager.LoadScene("Zadacha2");
    }

    public void LoadScen3()
    {
        SceneManager.LoadScene("Zadacha3");
    }
    public void LoadStart()
    {
        // загрузка главного меню
        SceneManager.LoadScene("Start");
    }
}

