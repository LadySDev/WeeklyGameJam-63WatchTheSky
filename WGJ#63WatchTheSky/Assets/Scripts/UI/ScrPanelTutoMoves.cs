using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrPanelTutoMoves : MonoBehaviour {

    private ScrGameManager scrGM;

    private Text txtTutoMoves;

    private bool isMoveLeftOk;
    private bool isMoveRightOk;

    // Use this for initialization
    void Start () {

        scrGM = GameObject.Find("GameManager").GetComponent<ScrGameManager>();

        txtTutoMoves = GameObject.Find("TxtTutoMoves").GetComponent<Text>();

        txtTutoMoves.text = "Push <color=#ff0000ff>Q</color> and <color=#ff0000ff>D</color> to move left and right";

        isMoveLeftOk = false;
        isMoveRightOk = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey("q") && isMoveLeftOk == false)
        {
            isMoveLeftOk = true;

            ChangeTextPanelTutoMoves();
        }
        else if (Input.GetKey("d") && isMoveRightOk == false)
        {
            isMoveRightOk = true;

            ChangeTextPanelTutoMoves();
        }
        
    }

    private void ChangeTextPanelTutoMoves()
    {
        if (isMoveLeftOk == true && isMoveRightOk == false)
        {

            txtTutoMoves.text = "Push <color=#008000ff>Q</color> and <color=#ff0000ff>D</color> to move left and right";

        }
        else if (isMoveLeftOk == false && isMoveRightOk == true)
        {

            txtTutoMoves.text = "Push <color=#ff0000ff>Q</color> and <color=#008000ff>D</color> to move left and right";

        }
        else if (isMoveLeftOk == true && isMoveRightOk == true)
        {
            txtTutoMoves.text = "Push <color=#008000ff>Q</color> and <color=#008000ff>D</color> to move left and right";

            Invoke("HidePanelTutoMoves", 1);
        }
    }

    private void HidePanelTutoMoves()
    {
        
        scrGM.ShowTxtMoney();

        scrGM.ShowPanelTutoCombat();

        gameObject.SetActive(false);
    }

}
