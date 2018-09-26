using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrBtnQuit : MonoBehaviour {

	// Use this for initialization
	void Start () {

        Button btnQuit = gameObject.GetComponent<Button>();
        btnQuit.onClick.AddListener(Quit);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Quit()
    {
        Application.Quit();
    }

}
