using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrProjectile : MonoBehaviour {

    [SerializeField]
    private float shootRate;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public float GetShootRate()
    {
        return shootRate;
    }

}
