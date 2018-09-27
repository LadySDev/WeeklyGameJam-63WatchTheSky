using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrBtnWeapon : MonoBehaviour {

    private string weaponName;
    private GameObject txtWeaponLevel;
    private Button btnWeapon;

    private bool isAlreadyBought;

    [SerializeField]
    private int cost;

    private ScrTxtMoney scrTxtMoney;

    [SerializeField]
    private GameObject alienShip;

    private bool isFightStarted;

    private void Awake()
    {
        weaponName = gameObject.name.Substring(3, 7);
        string strTxtWeaponLevel = "Txt" + weaponName + "Level";

        txtWeaponLevel = GameObject.Find(strTxtWeaponLevel);
        txtWeaponLevel.SetActive(false);

        string strTxtWeaponCost = "Txt" + weaponName + "Cost";
        GameObject.Find(strTxtWeaponCost).GetComponent<Text>().text = cost + " $";

        btnWeapon = gameObject.GetComponent<Button>();
        btnWeapon.onClick.AddListener(Event);

        isAlreadyBought = false;

        scrTxtMoney = GameObject.Find("TxtMoney").GetComponent< ScrTxtMoney>();

        isFightStarted = false;
    }

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

        int money = scrTxtMoney.GetMoney();

        if (isAlreadyBought == false && cost > money)
        {
            btnWeapon.interactable = false;
        }

        if (isFightStarted == true) {
            if (GameObject.Find("Soldier") == null)
            {
                GameObject.Find("GameManager").GetComponent<ScrGameManager>().SetIsPlayerLose(true);
            }
            else if (GameObject.Find("Alien") == null)
            {
                GameObject.Find("GameManager").GetComponent<ScrGameManager>().SetIsPlayerWin(true);
            }
        }
	}

    private void Event()
    {
        

        if (isAlreadyBought == false)
        {

            GameObject.Find("TxtMoney").GetComponent<ScrTxtMoney>().SetMoney(0);

            string txtWeaponCost = "Txt" + weaponName + "Cost";
            GameObject.Find(txtWeaponCost).SetActive(false);

            txtWeaponLevel.SetActive(true);
            
            isAlreadyBought = true;

            if (GameObject.Find("PanelTutoCombat"))
            {
                GameObject.Find("ImgArrow").SetActive(false);
                GameObject.Find("TxtTutoCombat").GetComponent<Text>().text = "As soon as an alien ship will appear, aim with the mouse and hold space to shoot";

                Invoke("FirstShoot", 3);

            }

        }
        else
        {
            TakeThisWeapon();
        }
        

    }

    private void TakeThisWeapon()
    {
        //print("take this");
    }

    private void FirstShoot()
    {
        GameObject.Find("PanelTutoCombat").SetActive(false);

        GameObject[] objScene = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (GameObject child in objScene)
        {
            if (child.name == "Trajectory")
            {
                child.SetActive(true);
            }

        }

        GameObject instanceAlienShip = Instantiate(alienShip);
        instanceAlienShip.transform.position = new Vector3(0, 5.5f, 0);
        instanceAlienShip.name = "Alien";

        GameObject soldier = GameObject.Find("Soldier");
       
        soldier.GetComponent<ScrSoldierCombat>().SetCurrentWeapon(1);

        isFightStarted = true;
    }

}
