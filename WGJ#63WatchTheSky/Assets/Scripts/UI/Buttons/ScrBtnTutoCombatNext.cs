using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrBtnTutoCombatNext : MonoBehaviour
{

    private int iteration;

    private ScrGameManager scrGM;
    private GameObject imgArrow;
    Text txtTutoCombat;

    // Use this for initialization
    void Start()
    {
        iteration = 0;

        scrGM = GameObject.Find("GameManager").GetComponent<ScrGameManager>();
        imgArrow = GameObject.Find("ImgArrow");
        txtTutoCombat = GameObject.Find("TxtTutoCombat").GetComponent<Text>();

        Button btnNext = gameObject.GetComponent<Button>();
        btnNext.onClick.AddListener(Next);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Next()
    {
        if (iteration == 0)
        {
            scrGM.ShowPanelShop();
                        
            imgArrow.GetComponent<RectTransform>().localPosition = new Vector3(250, -205, 0);

            txtTutoCombat.text = "Buy a weapon by clicking on it";

            iteration = 1;

            gameObject.SetActive(false);

        }

    }
}
