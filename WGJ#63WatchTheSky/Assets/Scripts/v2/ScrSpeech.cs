using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrSpeech : MonoBehaviour {
       
    private Sprite spriteButton;
    private Font font;

    private GameObject panelSpeech;

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
        panelSpeech = new GameObject("PanelSpeech");
        panelSpeech.transform.parent = GameObject.Find("Canvas").transform;
        panelSpeech.transform.localPosition = new Vector3(0, 0, 0);

        //Image
        GameObject imgSpeech = new GameObject("ImgSpeech");
        imgSpeech.transform.parent = panelSpeech.transform;        

        RectTransform rtImg = imgSpeech.AddComponent<RectTransform>();
        rtImg.transform.localPosition = new Vector3(0, 0, 0);
        rtImg.sizeDelta = new Vector2(600, 200);

        imgSpeech.AddComponent<CanvasRenderer>();

        Image imgImg = imgSpeech.AddComponent<Image>();

        //Text
        GameObject txtSpeech = new GameObject("TxtSpeech");
        txtSpeech.transform.parent = panelSpeech.transform;

        RectTransform rtTxt = txtSpeech.AddComponent<RectTransform>();
        rtTxt.transform.localPosition = new Vector3(0, 0, 0);
        rtTxt.sizeDelta = new Vector2(580, 180);

        txtSpeech.AddComponent<CanvasRenderer>();

        Text txtTxt = txtSpeech.AddComponent<Text>();
        txtTxt.text = "La planète est envahit par des vaisseaux aliens! Soldat, votre devoir est de la protéger, bon courage!";
        txtTxt.font = font;
        txtTxt.fontSize = 25;
        txtTxt.alignment = TextAnchor.MiddleCenter;
        txtTxt.color = Color.black;

        //Button
        GameObject btnSpeech = new GameObject("BtnSpeech");
        btnSpeech.transform.parent = panelSpeech.transform;

        RectTransform rtBtn = btnSpeech.AddComponent<RectTransform>();
        rtBtn.transform.localPosition = new Vector3(270, -80, 0);
        rtBtn.sizeDelta = new Vector2(50, 30);

        btnSpeech.AddComponent<CanvasRenderer>();

        Image imgBtn = btnSpeech.AddComponent<Image>();
        imgBtn.sprite = SpriteButton;
        imgBtn.type = Image.Type.Sliced;

        Button btn = btnSpeech.AddComponent<Button>();
        btn.onClick.AddListener(EndSpeech);

        //Button Text
        GameObject txtBtnSpeech = new GameObject("TxtBtnSpeech");
        txtBtnSpeech.transform.parent = btnSpeech.transform;

        RectTransform rtBtnTxt = txtBtnSpeech.AddComponent<RectTransform>();
        rtBtnTxt.transform.localPosition = new Vector3(0, 0, 0);
        rtBtnTxt.sizeDelta = new Vector2(50, 30);

        txtBtnSpeech.AddComponent<CanvasRenderer>();

        Text txtBtnTxt = txtBtnSpeech.AddComponent<Text>();
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
