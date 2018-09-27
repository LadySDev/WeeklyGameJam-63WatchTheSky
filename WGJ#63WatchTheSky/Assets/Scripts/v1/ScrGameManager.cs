using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrGameManager : MonoBehaviour {

    [SerializeField]
    private GameObject soldier;
    [SerializeField]
    private GameObject trajectory;

    private bool isPlayerLose;
    private bool isPlayerWin;

    private void SetResolutionsSettings()
    {
        Screen.SetResolution(800, 600, false);
    }

    private void Awake()
    {
        SetResolutionsSettings();
    }

    // Use this for initialization
    void Start () {

        SetResolutionsSettings();

        HidePanelTutoMoves();

        HideBtnMenu();
        HidePanelMenu();

        HideTxtMoney();
        HidePanelTutoCombat();

        HidePanelShop();

        isPlayerLose = false;
        isPlayerWin = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (isPlayerLose == true)
        {
            Lose();
        }

        if (isPlayerWin == true)
        {
            Win();
        }

    }

    //Tuto Moves
    public void ShowPanelTutoMoves()
    {
        GameObject[] objScene = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (GameObject child in objScene)
        {
            if (child.name == "PanelTutoMoves")
            {
                child.SetActive(true);
            }
        }
    }

    public void HidePanelTutoMoves()
    {
        GameObject.Find("PanelTutoMoves").SetActive(false);
    }

    //Button Menu
    public void ShowBtnMenu()
    {
        GameObject[] objScene = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (GameObject child in objScene)
        {
            if (child.name == "BtnMenu")
            {
                child.SetActive(true);
            }
        }
    }

    public void HideBtnMenu()
    {
        GameObject.Find("BtnMenu").SetActive(false);
    }

    //Panel Menu
    public void ShowPanelMenu()
    {
        
        GameObject[] objScene = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (GameObject child in objScene)
        {
            if (child.name == "PanelMenu")
            {
                child.SetActive(true);
            }
        }

    }

    public void HidePanelMenu()
    {
        GameObject.Find("PanelShop").SetActive(false);
    }

    //Text Money
    public void ShowTxtMoney()
    {

        GameObject[] objScene = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (GameObject child in objScene)
        {
            if (child.name == "TxtMoney")
            {
                child.SetActive(true);
            }
        }

    }

    public void HideTxtMoney()
    {
        GameObject.Find("TxtMoney").SetActive(false);
    }

    //Panel Tuto Combat
    public void ShowPanelTutoCombat()
    {

        GameObject[] objScene = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (GameObject child in objScene)
        {
            if (child.name == "PanelTutoCombat")
            {
                child.SetActive(true);
            }
        }

    }

    public void HidePanelTutoCombat()
    {
        GameObject.Find("PanelTutoCombat").SetActive(false);
    }

    //Panel Shop
    public void ShowPanelShop()
    {

        GameObject[] objScene = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (GameObject child in objScene)
        {
            if (child.name == "PanelShop")
            {
                child.SetActive(true);
            }
        }

    }

    public void HidePanelShop()
    {
        GameObject.Find("PanelMenu").SetActive(false);
    }


    //Soldier
    public void InstantiateSoldier()
    {
        GameObject instanceSoldier = Instantiate(soldier, new Vector3(0, -3.83f, 0), Quaternion.identity);
        instanceSoldier.name = "Soldier";

        GameObject instanceTrajectory = Instantiate(trajectory, instanceSoldier.transform);        
        instanceTrajectory.name = "Trajectory";

        instanceTrajectory.GetComponent<LineRenderer>().SetPosition(0, new Vector3(instanceSoldier.transform.position.x, instanceSoldier.transform.position.y + 0.5f, instanceSoldier.transform.position.z));
        instanceTrajectory.GetComponent<LineRenderer>().SetPosition(1, new Vector3(0, 3.84f, 0));
        
        instanceTrajectory.SetActive(false);
    }

    private void Lose()
    {
        ShowPanelMenu();
        GameObject.Find("TextResult").GetComponent<Text>().text = "You Lose !";
       

        isPlayerLose = false;
    }

    public void SetIsPlayerLose(bool isLose)
    {
        isPlayerLose = isLose;
    }

    public void SetIsPlayerWin(bool isWin)
    {
        isPlayerWin = isWin;
    }

    private void Win()
    {
        ShowPanelMenu();
        GameObject.Find("TextResult").GetComponent<Text>().text = "You Win !";
       

        isPlayerWin = false;
    }

}
