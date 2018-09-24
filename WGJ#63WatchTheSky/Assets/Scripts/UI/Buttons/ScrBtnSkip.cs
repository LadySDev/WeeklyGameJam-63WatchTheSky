using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrBtnSkip : MonoBehaviour {

    private ScrGameManager scrGM;

    // Use this for initialization
    void Start () {

        Button btnSkip = gameObject.GetComponent<Button>();
        btnSkip.onClick.AddListener(HideSpeech);

        scrGM = GameObject.Find("GameManager").GetComponent<ScrGameManager>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void HideSpeech()
    {
        GameObject.Find("Speech1").SetActive(false);
                
        scrGM.InstantiateSoldier();
        scrGM.ShowPanelTutoMoves();
    }

}
