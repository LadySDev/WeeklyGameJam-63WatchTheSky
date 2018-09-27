using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrMenu1 : MonoBehaviour {

    private Sprite spriteButton;
    private Font font;

    private GameObject panelMenu;
    private GameObject btnTutorial;
    private GameObject btnPlay;

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

        InitPanelMenu();
        
        InitButtonTutorial();
       
        InitTextButtonTutorial();
        
        InitButtonPlay();
        
        InitTextButtonPlay();
        
    }
        
    private void InitPanelMenu()
    {
        panelMenu = new GameObject("PanelMenu1");
        panelMenu.transform.parent = GameObject.Find("Canvas").transform;
        panelMenu.transform.localPosition = new Vector3(0, 0, 0);
    }

    private void InitButtonTutorial()
    {
        btnTutorial = new GameObject("BtnTuto");
        btnTutorial.transform.parent = panelMenu.transform;
        btnTutorial.transform.localPosition = new Vector3(0, 20, 0);

        RectTransform rtBtnTutorial = btnTutorial.AddComponent<RectTransform>();
        rtBtnTutorial.sizeDelta = new Vector2(160, 30);

        btnTutorial.AddComponent<CanvasRenderer>();

        Image imgBtnTutorial = btnTutorial.AddComponent<Image>();
        imgBtnTutorial.sprite = SpriteButton;
        imgBtnTutorial.type = Image.Type.Sliced;

        Button btnBtnTutorial = btnTutorial.AddComponent<Button>();
        btnBtnTutorial.onClick.AddListener(LaunchTutorial);
    }

    private void InitTextButtonTutorial()
    {
        GameObject txtBtnTutorial = new GameObject("TxtBtnSpeech");
        txtBtnTutorial.transform.parent = btnTutorial.transform;
        txtBtnTutorial.transform.localPosition = new Vector3(0, 0, 0);

        RectTransform rtTxtBtnTutorial = txtBtnTutorial.AddComponent<RectTransform>();
        rtTxtBtnTutorial.sizeDelta = new Vector2(160, 30);

        txtBtnTutorial.AddComponent<CanvasRenderer>();

        Text txtTxtBtnTutorial = txtBtnTutorial.AddComponent<Text>();
        txtTxtBtnTutorial.text = "Tutorial";
        txtTxtBtnTutorial.font = font;
        txtTxtBtnTutorial.fontSize = 25;
        txtTxtBtnTutorial.alignment = TextAnchor.MiddleCenter;
        txtTxtBtnTutorial.color = Color.black;
    }

    private void InitButtonPlay()
    {
        btnPlay = new GameObject("BtnPlay");
        btnPlay.transform.parent = panelMenu.transform;
        btnPlay.transform.localPosition = new Vector3(0, -20, 0);

        RectTransform rtBtnPlay = btnPlay.AddComponent<RectTransform>();
        rtBtnPlay.sizeDelta = new Vector2(160, 30);

        btnPlay.AddComponent<CanvasRenderer>();

        Image imgBtnPlay = btnPlay.AddComponent<Image>();
        imgBtnPlay.sprite = SpriteButton;
        imgBtnPlay.type = Image.Type.Sliced;

        Button btnBtnPlay = btnPlay.AddComponent<Button>();
        btnBtnPlay.onClick.AddListener(LaunchGame);
    }

    private void InitTextButtonPlay()
    {
        GameObject txtBtnPlay = new GameObject("TxtBtnSpeech");
        txtBtnPlay.transform.parent = btnPlay.transform;
        txtBtnPlay.transform.localPosition = new Vector3(0, 0, 0);

        RectTransform rtTxtBtnPlay = txtBtnPlay.AddComponent<RectTransform>();
        rtTxtBtnPlay.sizeDelta = new Vector2(160, 30);

        txtBtnPlay.AddComponent<CanvasRenderer>();

        Text txtTxtBtnPlay = txtBtnPlay.AddComponent<Text>();
        txtTxtBtnPlay.text = "Play";
        txtTxtBtnPlay.font = font;
        txtTxtBtnPlay.fontSize = 25;
        txtTxtBtnPlay.alignment = TextAnchor.MiddleCenter;
        txtTxtBtnPlay.color = Color.black;
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
