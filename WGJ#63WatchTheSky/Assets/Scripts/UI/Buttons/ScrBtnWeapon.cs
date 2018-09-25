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

    private void Awake()
    {
        weaponName = gameObject.name.Substring(3, 7);
        string strTxtWeaponLevel = "Txt" + weaponName + "Level";

        txtWeaponLevel = GameObject.Find(strTxtWeaponLevel);
        txtWeaponLevel.SetActive(false);

        string strTxtWeaponCost = "Txt" + weaponName + "Cost";
        GameObject.Find(strTxtWeaponCost).GetComponent<Text>().text = cost + " $";

        btnWeapon = gameObject.GetComponent<Button>();
        btnWeapon.onClick.AddListener(Buy);

        isAlreadyBought = false;

        scrTxtMoney = GameObject.Find("TxtMoney").GetComponent< ScrTxtMoney>();
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

	}

    private void Buy()
    {

        //spend money

        string txtWeaponCost = "Txt" + weaponName + "Cost";
        GameObject.Find(txtWeaponCost).SetActive(false);

        txtWeaponLevel.SetActive(true);

        btnWeapon.onClick.RemoveAllListeners();
        btnWeapon.onClick.AddListener(TakeThisWeapon);

        isAlreadyBought = true;

        if (GameObject.Find("PanelTutoCombat"))
        {
            GameObject.Find("ImgArrow").SetActive(false);
            GameObject.Find("TxtTutoCombat").GetComponent<Text>().text = "As soon as an alien ship will appear, aim with the mouse and hold space to shoot";

            Invoke("FirstShoot", 3);

        }

    }

    private void TakeThisWeapon()
    {
        print("take this");
    }

    private void FirstShoot()
    {
        GameObject.Find("PanelTutoCombat").SetActive(false);

        //soldier set current weapon

    }

}
