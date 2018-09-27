using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrSpeech : MonoBehaviour {
       
    private Sprite spriteButton;
    private Font font;

    private GameObject panelSpeech;
    private GameObject imgPanelSpeech;
    private GameObject btnPanelSpeech;

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

        InitPanelSpeech();
        
        InitImagePanelSpeech();
        
        InitTextPanelSpeech();
        
        InitButtonPanelSpeech();
        
        InitTextButtonPanelSpeech();
        
    }
    
    private void InitPanelSpeech()
    {        
        panelSpeech = new GameObject("PanelSpeech");
        panelSpeech.transform.parent = GameObject.Find("Canvas").transform;
        panelSpeech.transform.localPosition = new Vector3(0, 0, 0);
    }

    private void InitImagePanelSpeech()
    {       
        imgPanelSpeech = new GameObject("ImgSpeech");
        imgPanelSpeech.transform.parent = panelSpeech.transform;
        imgPanelSpeech.transform.localPosition = new Vector3(0, 0, 0);

        RectTransform rtImg = imgPanelSpeech.AddComponent<RectTransform>();       
        rtImg.sizeDelta = new Vector2(600, 200);

        imgPanelSpeech.AddComponent<CanvasRenderer>();

        Image imgImg = imgPanelSpeech.AddComponent<Image>();
    }

    private void InitTextPanelSpeech()
    {        
        GameObject txtPanelSpeech = new GameObject("TxtSpeech");
        txtPanelSpeech.transform.parent = imgPanelSpeech.transform;
        txtPanelSpeech.transform.localPosition = new Vector3(0, 0, 0);

        RectTransform rtTxt = txtPanelSpeech.AddComponent<RectTransform>();       
        rtTxt.sizeDelta = new Vector2(580, 180);

        txtPanelSpeech.AddComponent<CanvasRenderer>();

        Text txtTxt = txtPanelSpeech.AddComponent<Text>();
        txtTxt.text = "The planet is invaded by alien ships! Soldier, your duty is to protect her, good luck!";
        txtTxt.font = font;
        txtTxt.fontSize = 25;
        txtTxt.alignment = TextAnchor.MiddleCenter;
        txtTxt.color = Color.black;
    }

    private void InitButtonPanelSpeech()
    {
        btnPanelSpeech = new GameObject("BtnSpeech");
        btnPanelSpeech.transform.parent = panelSpeech.transform;
        btnPanelSpeech.transform.localPosition = new Vector3(270, -80, 0);

        RectTransform rtBtn = btnPanelSpeech.AddComponent<RectTransform>();
        rtBtn.sizeDelta = new Vector2(50, 30);

        btnPanelSpeech.AddComponent<CanvasRenderer>();

        Image imgBtn = btnPanelSpeech.AddComponent<Image>();
        imgBtn.sprite = SpriteButton;
        imgBtn.type = Image.Type.Sliced;

        Button btn = btnPanelSpeech.AddComponent<Button>();
        btn.onClick.AddListener(EndSpeech);
    }

    private void InitTextButtonPanelSpeech()
    {
        GameObject txtBtnPanelSpeech = new GameObject("TxtBtnSpeech");
        txtBtnPanelSpeech.transform.parent = btnPanelSpeech.transform;
        txtBtnPanelSpeech.transform.localPosition = new Vector3(0, 0, 0);

        RectTransform rtBtnTxt = txtBtnPanelSpeech.AddComponent<RectTransform>();
        rtBtnTxt.sizeDelta = new Vector2(50, 30);

        txtBtnPanelSpeech.AddComponent<CanvasRenderer>();

        Text txtBtnTxt = txtBtnPanelSpeech.AddComponent<Text>();
        txtBtnTxt.text = "Next";
        txtBtnTxt.font = font;
        txtBtnTxt.fontSize = 18;
        txtBtnTxt.alignment = TextAnchor.MiddleCenter;
        txtBtnTxt.color = Color.black;
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void EndSpeech()
    {

        gameObject.GetComponent<ScrGameManager2>().LaunchMenu1();

        Destroy(panelSpeech);
        Destroy(gameObject.GetComponent<ScrSpeech>());
    }

}
