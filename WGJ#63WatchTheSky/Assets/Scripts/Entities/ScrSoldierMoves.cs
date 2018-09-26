using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrSoldierMoves : MonoBehaviour {

    [SerializeField]
    private float moveSpeed;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey("q") && gameObject.transform.position.x > -6.1f)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x - moveSpeed, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        else if (Input.GetKey("d") && gameObject.transform.position.x < 4)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + moveSpeed, gameObject.transform.position.y, gameObject.transform.position.z);
        }

    }
}
