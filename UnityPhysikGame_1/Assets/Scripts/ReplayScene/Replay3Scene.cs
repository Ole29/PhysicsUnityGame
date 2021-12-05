using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Replay3Scene : MonoBehaviour
    {
        public Button button;
        private MainProgrScript ProgramMenegerScript;

    private void Start()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(Replays);
            ProgramMenegerScript = FindObjectOfType<MainProgrScript>();
        }
        void Replays()
        {
            // перезапуск 3ей задачи
            ProgramMenegerScript.PlaneMarketPrefab.SetActive(false);
            Destroy(ProgramMenegerScript.Mountain);
            Destroy(ProgramMenegerScript.Soild);
            Destroy(ProgramMenegerScript.BulletCopy);
            Destroy(ProgramMenegerScript.PickUpCar);
            Destroy(ProgramMenegerScript.Soldier2SmalForc);
            Destroy(ProgramMenegerScript.Soldier2BigForc);
            Destroy(ProgramMenegerScript.PanelGround3);

            ProgramMenegerScript.InputFieldSpeed1.SetActive(false);
            ProgramMenegerScript.GameOver.SetActive(false);
            ProgramMenegerScript.ButtnSpeed1.SetActive(false);
            ProgramMenegerScript.ConditZadach1.SetActive(false);
            ProgramMenegerScript.ChoseMarker = true;
            ProgramMenegerScript.NotForceSmall.SetActive(false);
            ProgramMenegerScript.ReplayScene2.SetActive(false);
            ProgramMenegerScript.ConditZadach3.SetActive(false);
            ProgramMenegerScript.InputLength3.SetActive(false);
            ProgramMenegerScript.ButtonLength3.SetActive(false);
            SceneManager.LoadScene("Zadacha3");

        }
    }

