using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Replay2Scene : MonoBehaviour
    {
        public Button button;
        private MainProgrScript mainProgrScript;
       
    private void Start()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(Replayss);
            mainProgrScript = FindObjectOfType<MainProgrScript>();
        }
        void Replayss()
        {
            // перезапуск 2ой задачи
            Destroy(mainProgrScript.Mountain);
            Destroy(mainProgrScript.Soild);
            Destroy(mainProgrScript.BulletCopy);
            mainProgrScript.ChoseMarker = true;
            mainProgrScript.GameOver.SetActive(false);
            mainProgrScript.NotForceSmall.SetActive(false);
            mainProgrScript.ReplayScene2.SetActive(false);
            mainProgrScript.PlaneMarketPrefab.SetActive(false);
            SceneManager.LoadScene("Zadacha2");
     
        }
    }

