using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScrNewGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Button>().onClick.AddListener(NewGame);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void NewGame()
    {
        SceneManager.LoadScene(0);
    }
}
