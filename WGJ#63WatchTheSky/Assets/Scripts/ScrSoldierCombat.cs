using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrSoldierCombat : MonoBehaviour {

    [SerializeField]
    private GameObject[] weaponsProjectiles;

    private GameObject currentWeaponProjectile;

    private float shootTimer;

	// Use this for initialization
	void Start () {
        shootTimer = 0;
	}
	
	// Update is called once per frame
	void Update () {

        shootTimer = shootTimer + Time.deltaTime;
                
        if (currentWeaponProjectile != null && Input.GetKey("space") && currentWeaponProjectile.GetComponent<ScrProjectile>().GetShootRate() <= shootTimer)
        {
            print("piou");

            shootTimer = 0;
        }

	}

    public void SetCurrentWeapon(int number)
    {
        currentWeaponProjectile = weaponsProjectiles[number - 1];                
    }

    public bool IsCurrentWeaponSet()
    {
        return currentWeaponProjectile != null;
    }

}
