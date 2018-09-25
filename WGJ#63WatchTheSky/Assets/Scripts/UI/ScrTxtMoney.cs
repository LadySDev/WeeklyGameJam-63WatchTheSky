using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrTxtMoney : MonoBehaviour {

    [SerializeField]
    private int money;

    private Text txtMoney;

	// Use this for initialization
	void Start () {
        txtMoney = gameObject.GetComponent<Text>();
        txtMoney.text = money + " $";
    }
	
	// Update is called once per frame
	void Update () {
        txtMoney.text = money + " $";
    }

    public void SetMoney(int number)
    {
        money = number;
    }

    public int GetMoney()
    {
        return money;
    }

}
