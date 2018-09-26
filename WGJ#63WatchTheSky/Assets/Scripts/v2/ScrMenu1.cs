using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrMenu1 : MonoBehaviour {

    private Sprite spriteButton;
    private Font font;

    private GameObject panelMenu;

    // Sprite Button Getter Setter
    public Sprite SpriteButton
    {
        get
        {
            return spriteButton;
        }

        set
        {
            spriteButton = value;
        }
    }

    // Font Getter Setter
    public Font Font
    {
        get
        {
            return font;
        }

        set
        {
            font = value;
        }
    }

    // Use this for initialization
    void Start () {

        //Panel
        panelMenu = new GameObject("PanelMenu1");
        panelMenu.transform.parent = GameObject.Find("Canvas").transform;
        panelMenu.transform.localPosition = new Vector3(0, 0, 0);



        //Button Launch Tuto
        GameObject btnTuto = new GameObject("BtnTuto");
        btnTuto.transform.parent = panelMenu.transform;

        RectTransform rtBtnTuto = btnTuto.AddComponent<RectTransform>();
        rtBtnTuto.transform.localPosition = new Vector3(0, 20, 0);
        rtBtnTuto.sizeDelta = new Vector2(160, 30);

        btnTuto.AddComponent<CanvasRenderer>();

        Image imgBtnTuto = btnTuto.AddComponent<Image>();
        imgBtnTuto.sprite = SpriteButton;
        imgBtnTuto.type = Image.Type.Sliced;

        Button btnBtnTuto = btnTuto.AddComponent<Button>();
        btnBtnTuto.onClick.AddListener(LaunchTutorial);

        //Button Text Launch Tuto
        GameObject txtBtnTuto = new GameObject("TxtBtnSpeech");
        txtBtnTuto.transform.parent = btnTuto.transform;

        RectTransform rtBtnTutoTxt = txtBtnTuto.AddComponent<RectTransform>();
        rtBtnTutoTxt.transform.localPosition = new Vector3(0, 0, 0);
        rtBtnTutoTxt.sizeDelta = new Vector2(160, 30);

        txtBtnTuto.AddComponent<CanvasRenderer>();

        Text txtBtnTutoTxt = txtBtnTuto.AddComponent<Text>();
        txtBtnTutoTxt.text = "Tutorial";
        txtBtnTutoTxt.font = font;
        txtBtnTutoTxt.fontSize = 20;
        txtBtnTutoTxt.alignment = TextAnchor.MiddleCenter;
        txtBtnTutoTxt.color = Color.black;




        //Button Launch Play
        GameObject btnPlay = new GameObject("BtnPlay");
        btnPlay.transform.parent = panelMenu.transform;

        RectTransform rtBtnPlay = btnPlay.AddComponent<RectTransform>();
        rtBtnPlay.transform.localPosition = new Vector3(0, -20, 0);
        rtBtnPlay.sizeDelta = new Vector2(160, 30);

        btnPlay.AddComponent<CanvasRenderer>();

        Image imgBtnPlay = btnPlay.AddComponent<Image>();
        imgBtnPlay.sprite = SpriteButton;
        imgBtnPlay.type = Image.Type.Sliced;

        Button btnBtnPlay = btnPlay.AddComponent<Button>();
        btnBtnPlay.onClick.AddListener(LaunchGame);

        //Button Text Launch Tuto
        GameObject txtBtnPlay = new GameObject("TxtBtnSpeech");
        txtBtnPlay.transform.parent = btnPlay.transform;

        RectTransform rtBtnPlayTxt = txtBtnPlay.AddComponent<RectTransform>();
        rtBtnPlayTxt.transform.localPosition = new Vector3(0, 0, 0);
        rtBtnPlayTxt.sizeDelta = new Vector2(160, 30);

        txtBtnPlay.AddComponent<CanvasRenderer>();

        Text txtBtnPlayTxt = txtBtnPlay.AddComponent<Text>();
        txtBtnPlayTxt.text = "Play";
        txtBtnPlayTxt.font = font;
        txtBtnPlayTxt.fontSize = 20;
        txtBtnPlayTxt.alignment = TextAnchor.MiddleCenter;
        txtBtnPlayTxt.color = Color.black;

    }
        
    private void LaunchTutorial()
    {
        gameObject.GetComponent<ScrGameManager2>().LaunchTutorial();

        EndMenu();
    }

    private void LaunchGame()
    {
        gameObject.GetComponent<ScrGameManager2>().LaunchGame();

        EndMenu();
    }

    private void EndMenu()
    {
        Destroy(gameObject.GetComponent<ScrMenu1>());

        Destroy(panelMenu);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
