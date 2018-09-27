using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrGameManager2 : MonoBehaviour {

    [SerializeField]
    private Sprite spriteButton;

    [SerializeField]
    private Font font;

    [SerializeField]
    private float screenPosXMin;
    [SerializeField]
    private float screenPosXMax;

    [SerializeField]
    private GameObject soldier;

    [SerializeField]
    private float soldierPosY;

    [SerializeField]
    private Sprite arrow;

    [SerializeField]
    private GameObject alien;

    //screenPosXMin Getter Setter
    public float ScreenPosXMin
    {
        get
        {
            return screenPosXMin;
        }

        set
        {
            screenPosXMin = value;
        }
    }

    //screenPosXMax Getter Setter
    public float ScreenPosXMax
    {
        get
        {
            return screenPosXMax;
        }

        set
        {
            screenPosXMax = value;
        }
    }

    // Use this for initialization
    void Start () {

        //launch speech
        ScrSpeech scrSpeech = gameObject.AddComponent<ScrSpeech>();
        scrSpeech.SpriteButton = spriteButton;
        scrSpeech.Font = font;

    }
	
	// Update is called once per frame
	void Update () {
		
        //si speech end launch menu1 (choice 1 : launch tuto, choice 2: play)

	}

    public void LaunchMenu1()
    {

        ScrMenu1 scrMenu1 = gameObject.AddComponent<ScrMenu1>();
        scrMenu1.SpriteButton = spriteButton;
        scrMenu1.Font = font;

    }

    public void LaunchTutorial()
    {
        ScrTutorial scrTutorial = gameObject.AddComponent<ScrTutorial>();
        scrTutorial.SpriteButton = spriteButton;
        scrTutorial.Font = font;
        scrTutorial.Soldier = soldier;
        scrTutorial.SoldierPosY = soldierPosY;
        scrTutorial.Arrow = arrow;
        scrTutorial.Alien = alien;
    }

    public void LaunchGame()
    {
        print("Launch game");
    }

}
