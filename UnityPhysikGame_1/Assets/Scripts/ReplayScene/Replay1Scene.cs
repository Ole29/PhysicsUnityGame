
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Replay1Scene : MonoBehaviour
{
    public Button button;
    private MainProgrScript ProgramMenegerScript;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Replayss);
        ProgramMenegerScript = FindObjectOfType<MainProgrScript>();

    }
    void Replayss()
    {
        // перезапуск 1ой задачи
        ProgramMenegerScript.PlaneMarketPrefab.SetActive(false);
        ProgramMenegerScript.InputFieldSpeed1.SetActive(false);
        ProgramMenegerScript.GameOver.SetActive(false);
        ProgramMenegerScript.ButtnSpeed1.SetActive(false);
        ProgramMenegerScript.ConditZadach1.SetActive(false);
        ProgramMenegerScript.ChoseMarker = true;
        ProgramMenegerScript.NotForceSmall.SetActive(false);
        ProgramMenegerScript.ReplayScene2.SetActive(false);
        SceneManager.LoadScene("Zadacha11");

    }
}

