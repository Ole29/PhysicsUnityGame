using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonStart : MonoBehaviour
{

    // Update is called once per frame
  public void ButTouch()
    {
        GetComponent<Animation>().Play("ButStart");
    }
}
