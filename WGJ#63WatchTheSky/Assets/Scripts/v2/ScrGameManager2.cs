using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrGameManager2 : MonoBehaviour {

    [SerializeField]
    private Sprite spriteButton;

    [SerializeField]
    private Font font;

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
        print("Launch tutorial");
    }

    public void LaunchGame()
    {
        print("Launch game");
    }

}
