using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.SceneManagement;

public class MainProgrScript : MonoBehaviour
{
    private ARRaycastManager aRRaycastManagerScript;// ссылка на скрипт ARRaycastManager

    public GameObject PlaneMarketPrefab;
    public bool ChoseMarker = false;

    private float height;
    private float max = 0.4f;
    private float min = 0.3f;

    public GameObject ObjectToSpawnGround;
    public GameObject SoilderScene1;
    public GameObject UnvisibleObject;
    public GameObject Bullet;
    public GameObject DestroyBullet;
    public GameObject BulletBigSpeed;
    public GameObject PickUpCar;
    public GameObject Crystal;

    public GameObject InputFieldSpeed1;
    public GameObject ButtnSpeed1;
    public GameObject ConditZadach1;
    public GameObject ReplayButtnSc1;


    public GameObject ConditZadach2;
    public GameObject InputForce2;
    public GameObject ButtnForce2;
    public GameObject ReplayScene2;

    public GameObject SoldierScene2;
    public GameObject Panelground2;
    public GameObject Soldier2SmalForc;
    public GameObject Soldier2BigForc;

    public GameObject GameOver;
    public GameObject WinMessag;

    public GameObject EssencialMessage;
    public GameObject BreakMessage;
    public GameObject NotForceSmall;


    public GameObject SoldierShotScene3;
    public GameObject Sphere3SmalL;
    public GameObject PanelGround3;
    public GameObject SoildCatchBull;
    public GameObject Spere;
    public GameObject CatchSphere3;

    public GameObject ConditZadach3;
    public GameObject InputLength3;
    public GameObject InputHeight3;
    public GameObject ButtonLength3;

    public GameObject TooMinSpeed;
    public GameObject TooMaxSpeed;
    public GameObject Horizontal;
    public GameObject Monitor;

    public GameObject Mountain;
    public GameObject Soild;
    public GameObject BulletCopy;

    public GameObject ReplayScene3;
    public GameObject NotForceBig;
    public GameObject WRONG;

    public GameObject LittleLengt;
    public GameObject LittleHeught;
    public GameObject BigHeught;
    public GameObject BigLengt;
    public GameObject ReplMenu;
    public GameObject Sphere3Bigg;
    public GameObject NotInputHegtL;
    public GameObject ReplMenuAgain;
    public GameObject GreatMessag;
    public GameObject NotInputForce;

    private string Scen;
    private void Start()
    {
        // получение имени текущей сцены
        Scen = SceneManager.GetActiveScene().name;
 
        aRRaycastManagerScript = FindObjectOfType<ARRaycastManager>();

        // сокрытие интерфейса при запуске приложения
        Monitor.SetActive(false);
        PlaneMarketPrefab.SetActive(false);
        ReplMenuAgain.SetActive(false);
        Horizontal.SetActive(false);

        if (Scen.Equals("Zadacha11")) {

            InputFieldSpeed1.SetActive(false);
            ButtnSpeed1.SetActive(false);
            ConditZadach1.SetActive(false);
            ReplayButtnSc1.SetActive(false);
            TooMinSpeed.SetActive(false);
            TooMaxSpeed.SetActive(false);
            
        }


        if ((Scen.Equals("Zadacha2")) || (Scen.Equals("Zadacha11"))) {

            GreatMessag.SetActive(false);
            ConditZadach2.SetActive(false);
            InputForce2.SetActive(false);
            ButtnForce2.SetActive(false);
            NotInputForce.SetActive(false);
            ReplayScene2.SetActive(false);
            EssencialMessage.SetActive(false);
            BreakMessage.SetActive(false);
            NotForceSmall.SetActive(false);
            NotForceBig.SetActive(false);
        }

        NotInputHegtL.SetActive(false);

        WinMessag.SetActive(false);
        GameOver.SetActive(false);
        
        ConditZadach3.SetActive(false);
        InputLength3.SetActive(false);
        ButtonLength3.SetActive(false);
        InputHeight3.SetActive(false);
        ReplayScene3.SetActive(false);  
        WRONG.SetActive(false);

        LittleHeught.SetActive(false);
        LittleLengt.SetActive(false);
        BigHeught.SetActive(false);
        BigLengt.SetActive(false);
        ReplMenu.SetActive(false);
    }

   private void Update()
    {
             if (ChoseMarker)
             {
                ShowMarkerAndSetObject();
             }
    }
   
    // появление объектов игры на сцене
    private void ShowMarkerAndSetObject()
    {
        // контейнер, куда будут попадать все обнаруженные объекты (плоскости)
        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        // луч из центра экрана, который будет искать плоские поверхности
        aRRaycastManagerScript.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

            // если ни одна поверхность не обнаружена, тогда продолжаем поиск 
            if (hits.Count == 0) {
                Horizontal.SetActive(true);
                Monitor.SetActive(false);
                PlaneMarketPrefab.SetActive(false);
            }
            else {

                ReplMenuAgain.SetActive(true);
                Horizontal.SetActive(false);

                // берем позицию маркера и присваем ей значение плоскоти (того места, где пересеклись лучи с плоскостью)
                PlaneMarketPrefab.transform.position = hits[0].pose.position;

                // активируем наш маркерт в этом случае
                PlaneMarketPrefab.SetActive(true);      

                // если пользователь коснулся экрана, то объекты появляются на сцене
                if (Input.touchCount == 1 && Input.touches[0].phase == TouchPhase.Began)
                {

                    Monitor.SetActive(false);
                    height = ObjectToSpawnGround.GetComponent<RectTransform>().localScale.y;
                    height = Random.Range(min, max);

                    // появление объектов и присвоение им координат
                    Mountain = Instantiate(ObjectToSpawnGround, hits[0].pose.position, ObjectToSpawnGround.transform.rotation);
                    Mountain.GetComponent<RectTransform>().localScale = new Vector3(Mountain.transform.localScale.x, height, Mountain.transform.localScale.z);

                    Soild = Instantiate(SoilderScene1, hits[0].pose.position, SoilderScene1.transform.rotation);

                if (Scen.Equals("Zadacha2"))
                {
                    Soild.GetComponent<RectTransform>().position = new Vector3(Soild.transform.position.x - 0.05f, height - 0.2f, Soild.transform.position.z - 0.23f);

                    BulletCopy = Instantiate(Bullet, hits[0].pose.position, Bullet.transform.rotation);
                    BulletCopy.GetComponent<RectTransform>().position = new Vector3(Mountain.transform.position.x - 0.08f, Mountain.transform.position.y + 0.44f, Mountain.transform.position.z - 0.49f);//z - 0.45

                }
                else if (Scen.Equals("Zadacha3")) {

                    Soild.GetComponent<RectTransform>().position = new Vector3(Soild.transform.position.x - 0.05f, height - 0.2f, Soild.transform.position.z + 0.08f);
                    BulletCopy = (GameObject)Instantiate(Bullet, Bullet.transform.position, Bullet.transform.rotation);
                    BulletCopy.GetComponent<RectTransform>().position = new Vector3(Mountain.transform.position.x - 0.08f, Soild.transform.position.y + 0.13f, Mountain.transform.position.z - 0.49f);

                }
                else
                {
                    Soild.GetComponent<RectTransform>().position = new Vector3(Soild.transform.position.x - 0.05f, height - 0.2f, Soild.transform.position.z + 0.03f);
                }
                    
                    UnvisibleObject = Instantiate(UnvisibleObject, hits[0].pose.position, UnvisibleObject.transform.rotation);
                    UnvisibleObject.GetComponent<RectTransform>().position = new Vector3(Mountain.transform.position.x + 0.07f, Mountain.transform.position.y + 0.7f, Mountain.transform.position.z - 0.31f);

                    PickUpCar = Instantiate(PickUpCar, hits[0].pose.position, PickUpCar.transform.rotation);
                    PickUpCar.GetComponent<RectTransform>().position = new Vector3(Mountain.transform.position.x - 0.15f, Mountain.transform.position.y - 0.07f, Mountain.transform.position.z - 0.65f);// z - 0.7

                PlaneMarketPrefab.SetActive(false);
                    ChoseMarker = false;
                }
                else
                {
                    Monitor.SetActive(true);
                }
            
        }

    }
  
}
