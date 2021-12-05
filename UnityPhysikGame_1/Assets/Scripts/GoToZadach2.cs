using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoToZadach2 : MonoBehaviour
{
    public Button BreakButton;
    private MainProgrScript ScriptProgMan;

    void Start()
    {
        BreakButton = GetComponent<Button>();
        BreakButton.onClick.AddListener(Zadach2);
        ScriptProgMan = FindObjectOfType<MainProgrScript>();
    }

    public void Zadach2()
    {
        //загрузка условия 2ой задачи
        ScriptProgMan.BreakMessage.SetActive(false);
        ScriptProgMan.ConditZadach2.SetActive(true);
        ScriptProgMan.InputForce2.SetActive(true);
        ScriptProgMan.ButtnForce2.SetActive(true);
    }
}
