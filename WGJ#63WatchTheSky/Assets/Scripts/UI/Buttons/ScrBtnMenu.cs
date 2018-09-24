using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrBtnMenu : MonoBehaviour {

    private ScrGameManager scrGM;

    // Use this for initialization
    void Start () {

        Button btnMenu = gameObject.GetComponent<Button>();
        btnMenu.onClick.AddListener(ShowPanelMenu);

        scrGM = GameObject.Find("GameManager").GetComponent< ScrGameManager>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void ShowPanelMenu()
    {
        scrGM.ShowPanelMenu();
    }

}
