using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrTutorial : MonoBehaviour {

    private Sprite spriteButton;
    private Font font;

    private GameObject soldier;
    private float soldierPosY;

    private GameObject instanceSoldier;

    private GameObject panelTutorial;
    private GameObject imgPanelTutorial;

    private Text txtTxtPanelTutorial;

    private bool isItTutoMove;

    private bool isMoveLeft;
    private bool isMoveRight;

    private Sprite arrow;
    private GameObject imgArrow;

    private ScrTextMoney scrTxtMoney;

    private GameObject btnNext;

    private GameObject btnWeapon1;
    private GameObject txtCostBtnWeapon1;

    private GameObject alien;

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

    // Soldier Getter Setter
    public GameObject Soldier
    {
        get
        {
            return soldier;
        }

        set
        {
            soldier = value;
        }
    }

    // Soldier Position Y Getter Setter
    public float SoldierPosY
    {
        get
        {
            return soldierPosY;
        }

        set
        {
            soldierPosY = value;
        }
    }

    // Arrow Getter Setter
    public Sprite Arrow
    {
        get
        {
            return arrow;
        }

        set
        {
            arrow = value;
        }
    }

    // Alien Getter Setter
    public GameObject Alien
    {
        get
        {
            return alien;
        }

        set
        {
            alien = value;
        }
    }

    // Use this for initialization
    void Start () {

        instanceSoldier = Instantiate(soldier, GameObject.Find("SoldierPart").transform);
        instanceSoldier.name = "Soldier";
        instanceSoldier.transform.position = new Vector3(0, soldierPosY, 0);                

        foreach (Transform child in instanceSoldier.GetComponentInChildren<Transform>())
        {
            child.gameObject.SetActive(false);
        }

        //only moves activate

        InitPanelTutorial();

        InitImagePanelTutorial();

        InitTextPanelTutorial();

        isItTutoMove = true;

        isMoveLeft = false;
        isMoveRight = false;

    }
	
    private void InitPanelTutorial()
    {
        panelTutorial = new GameObject("PanelTutorial");
        panelTutorial.transform.parent = GameObject.Find("Canvas").transform;
        panelTutorial.transform.localPosition = new Vector3(0, 0, 0);
    }

    private void InitImagePanelTutorial()
    {
        imgPanelTutorial = new GameObject("ImgTutorial");
        imgPanelTutorial.transform.parent = panelTutorial.transform;
        imgPanelTutorial.transform.localPosition = new Vector3(0, 0, 0);

        RectTransform rtImg = imgPanelTutorial.AddComponent<RectTransform>();
        rtImg.sizeDelta = new Vector2(350, 110);

        imgPanelTutorial.AddComponent<CanvasRenderer>();

        Image imgImg = imgPanelTutorial.AddComponent<Image>();
    }

    private void InitTextPanelTutorial()
    {
        GameObject txtPanelTutorial = new GameObject("TxtTutorial");
        txtPanelTutorial.transform.parent = imgPanelTutorial.transform;
        txtPanelTutorial.transform.localPosition = new Vector3(0, 0, 0);

        RectTransform rtTxt = txtPanelTutorial.AddComponent<RectTransform>();
        rtTxt.sizeDelta = new Vector2(330, 90);

        txtPanelTutorial.AddComponent<CanvasRenderer>();

        txtTxtPanelTutorial = txtPanelTutorial.AddComponent<Text>();
        txtTxtPanelTutorial.text = "Push <color=#ff0000ff>Q</color> and <color=#ff0000ff>D</color> to move left and right";
        txtTxtPanelTutorial.font = font;
        txtTxtPanelTutorial.fontSize = 25;
        txtTxtPanelTutorial.alignment = TextAnchor.MiddleCenter;
        txtTxtPanelTutorial.color = Color.black;
    }

    // Update is called once per frame
    void Update () {

        if (isItTutoMove == true)
        {
            if (Input.GetKey("q") && isMoveLeft == false)
            {
                isMoveLeft = true;

                ChangeTextPanelTutorial();
            }
            else if (Input.GetKey("d") && isMoveRight == false)
            {
                isMoveRight = true;

                ChangeTextPanelTutorial();
            }
        }
        
	}

    private void ChangeTextPanelTutorial()
    {
        if (isMoveLeft == true && isMoveRight == false)
        {

            txtTxtPanelTutorial.text = "Push <color=#008000ff>Q</color> and <color=#ff0000ff>D</color> to move left and right";

        }
        else if (isMoveLeft == false && isMoveRight == true)
        {

            txtTxtPanelTutorial.text = "Push <color=#ff0000ff>Q</color> and <color=#008000ff>D</color> to move left and right";

        }
        else if (isMoveLeft == true && isMoveRight == true)
        {
            txtTxtPanelTutorial.text = "Push <color=#008000ff>Q</color> and <color=#008000ff>D</color> to move left and right";
                        
            Invoke("StartPart2", 1);
            
        }
    }

    private void StartPart2()
    {
        isItTutoMove = false;

        Destroy(instanceSoldier);
               
        txtTxtPanelTutorial.text = "This is your money";

        InitImageArrow();

        InitTextMoney();

        InitButtonNext();

        InitTextButtonNext();
    }

    private void InitImageArrow()
    {
        imgArrow = new GameObject("ImgArrow");
        imgArrow.transform.parent = panelTutorial.transform;
        imgArrow.transform.localPosition = new Vector3(-365, -230, 0);

        RectTransform rtImgArrow = imgArrow.AddComponent<RectTransform>();
        rtImgArrow.sizeDelta = new Vector2(60, 60);

        imgArrow.AddComponent<CanvasRenderer>();

        Image imgImgArrow = imgArrow.AddComponent<Image>();
        imgImgArrow.sprite = arrow;
    }

    private void InitTextMoney()
    {
        GameObject txtMoney = new GameObject("TxtMoney");
        txtMoney.transform.parent = GameObject.Find("Canvas").transform;
        txtMoney.transform.localPosition = new Vector3(-390, -280, 0);

        RectTransform rtTxtMoney = txtMoney.AddComponent<RectTransform>();
        rtTxtMoney.sizeDelta = new Vector2(200, 40);
        rtTxtMoney.pivot = new Vector2(0, 0.5f);

        txtMoney.AddComponent<CanvasRenderer>();

        Text txtTxtMoney = txtMoney.AddComponent<Text>();
        txtTxtMoney.text = "Money";
        txtTxtMoney.font = font;
        txtTxtMoney.fontSize = 35;
        txtTxtMoney.alignment = TextAnchor.MiddleLeft;
        txtTxtMoney.color = Color.black;

        scrTxtMoney = txtMoney.AddComponent<ScrTextMoney>();
        scrTxtMoney.SetMoney(5);
    }

    private void InitButtonNext()
    {
        btnNext = new GameObject("BtnNext");
        btnNext.transform.parent = panelTutorial.transform;
        btnNext.transform.localPosition = new Vector3(145, -35, 0);

        RectTransform rtBtn = btnNext.AddComponent<RectTransform>();
        rtBtn.sizeDelta = new Vector2(50, 30);

        btnNext.AddComponent<CanvasRenderer>();

        Image imgBtn = btnNext.AddComponent<Image>();
        imgBtn.sprite = SpriteButton;
        imgBtn.type = Image.Type.Sliced;

        Button btn = btnNext.AddComponent<Button>();
        btn.onClick.AddListener(StartPart3);
    }

    private void InitTextButtonNext()
    {
        GameObject txtBtnNext = new GameObject("TxtBtnNext");
        txtBtnNext.transform.parent = btnNext.transform;
        txtBtnNext.transform.localPosition = new Vector3(0, 0, 0);

        RectTransform rtBtnTxt = txtBtnNext.AddComponent<RectTransform>();
        rtBtnTxt.sizeDelta = new Vector2(50, 30);

        txtBtnNext.AddComponent<CanvasRenderer>();

        Text txtBtnTxt = txtBtnNext.AddComponent<Text>();
        txtBtnTxt.text = "Next";
        txtBtnTxt.font = font;
        txtBtnTxt.fontSize = 18;
        txtBtnTxt.alignment = TextAnchor.MiddleCenter;
        txtBtnTxt.color = Color.black;
    }

    private void StartPart3()
    {
        txtTxtPanelTutorial.text = "Buy a weapon by clicking on it";

        Destroy(btnNext);

        imgArrow.transform.localPosition = new Vector3(250, -205, 0);
        imgArrow.transform.rotation = Quaternion.Euler(0, 0, 90);

        InitButtonWeapon1();

        InitTextNameButtonWeapon1();

        InitTextCostButtonWeapon1();

    }

    private void InitButtonWeapon1()
    {
        btnWeapon1 = new GameObject("BtnWeapon1");
        btnWeapon1.transform.parent = GameObject.Find("Canvas").transform;
        btnWeapon1.transform.localPosition = new Vector3(345.5f, -210, 0);

        RectTransform rtBtn = btnWeapon1.AddComponent<RectTransform>();
        rtBtn.sizeDelta = new Vector2(90, 90);

        btnWeapon1.AddComponent<CanvasRenderer>();

        Image imgBtn = btnWeapon1.AddComponent<Image>();
        imgBtn.sprite = SpriteButton;
        imgBtn.type = Image.Type.Sliced;

        Button btn = btnWeapon1.AddComponent<Button>();
        btn.onClick.AddListener(StartPart4);
    }

    private void InitTextNameButtonWeapon1()
    {
        GameObject txtNameBtnWeapon1 = new GameObject("TxtWeapon1Name");
        txtNameBtnWeapon1.transform.parent = btnWeapon1.transform;
        txtNameBtnWeapon1.transform.localPosition = new Vector3(0, 0, 0);

        RectTransform rtBtnTxt = txtNameBtnWeapon1.AddComponent<RectTransform>();
        rtBtnTxt.anchorMin = new Vector2(0, 0);
        rtBtnTxt.anchorMax = new Vector2(1, 1);
        
        rtBtnTxt.sizeDelta = new Vector2(50, 30);

        txtNameBtnWeapon1.AddComponent<CanvasRenderer>();

        Text txtBtnTxt = txtNameBtnWeapon1.AddComponent<Text>();
        txtBtnTxt.text = "Weapon1";
        txtBtnTxt.font = font;
        txtBtnTxt.fontSize = 20;
        txtBtnTxt.alignment = TextAnchor.MiddleCenter;
        txtBtnTxt.color = Color.black;
    }

    private void InitTextCostButtonWeapon1()
    {
        txtCostBtnWeapon1 = new GameObject("TxtWeapon1Cost");
        txtCostBtnWeapon1.transform.parent = btnWeapon1.transform;
        txtCostBtnWeapon1.transform.localPosition = new Vector3(0, 0, 0);

        RectTransform rtBtnTxt = txtCostBtnWeapon1.AddComponent<RectTransform>();
        rtBtnTxt.sizeDelta = new Vector2(50, 30);
        rtBtnTxt.anchorMin = new Vector2(0, 0);
        rtBtnTxt.anchorMax = new Vector2(1, 1);
        rtBtnTxt.offsetMin = new Vector2(0, 0);
        rtBtnTxt.offsetMax = new Vector2(0, -70);

        txtCostBtnWeapon1.AddComponent<CanvasRenderer>();

        Text txtBtnTxt = txtCostBtnWeapon1.AddComponent<Text>();
        txtBtnTxt.text = "5 $";
        txtBtnTxt.font = font;
        txtBtnTxt.fontSize = 16;
        txtBtnTxt.alignment = TextAnchor.LowerCenter;
        txtBtnTxt.color = Color.black;
    }

    private void StartPart4()
    {
        scrTxtMoney.SetMoney(0);
        Destroy(imgArrow);
        Destroy(txtCostBtnWeapon1);

        txtTxtPanelTutorial.text = "As soon as an alien ship will appear, aim with the mouse and hold space to shoot";

        instanceSoldier = Instantiate(soldier, GameObject.Find("SoldierPart").transform);
        instanceSoldier.name = "Soldier";
        instanceSoldier.transform.position = new Vector3(0, soldierPosY, 0);
        instanceSoldier.GetComponent<ScrSoldierCombat2>().SetCurrentWeapon(1);

        Invoke("StartPart5", 3);
    }

    private void StartPart5()
    {
        Destroy(panelTutorial);        

        GameObject instanceAlien = Instantiate(alien, GameObject.Find("AlienArmy").transform);
        instanceAlien.name = "Alien";
        instanceAlien.transform.position = new Vector3(0, 5.5f, 0);
    }

}
