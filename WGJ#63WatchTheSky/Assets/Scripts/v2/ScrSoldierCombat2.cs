using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrSoldierCombat2 : MonoBehaviour {

    [SerializeField]
    private GameObject[] weaponsProjectiles;

    private GameObject currentWeaponProjectile;

    private GameObject soldierProjectiles;
    private float shootTimer;


    [SerializeField]
    private int healthMax;
    [SerializeField]
    private int health;

   

    public void SetCurrentWeapon(int number)
    {
        currentWeaponProjectile = weaponsProjectiles[number - 1];
    }

    public bool IsCurrentWeaponSet()
    {
        return currentWeaponProjectile != null;
    }

    public int GetHealthMax()
    {
        return healthMax;
    }

    public int GetHealth()
    {
        return health;
    }

    // Use this for initialization
    void Start () {
        soldierProjectiles = GameObject.Find("SoldierProjectiles");

        shootTimer = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        shootTimer = shootTimer + Time.deltaTime;

        if (currentWeaponProjectile != null && Input.GetKey("space") && currentWeaponProjectile.GetComponent<ScrProjectile2>().GetShootRate() <= shootTimer)
        {
            Vector3 startPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.5f, gameObject.transform.position.z);
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 goalPos = new Vector3(mousePos.x, 3.84f, 0);

            GameObject instance = Instantiate(currentWeaponProjectile, soldierProjectiles.transform);
            instance.transform.position = startPos;
            instance.GetComponent<ScrProjectile2>().SetGoalPosition(goalPos);

            shootTimer = 0;
        }
    }

    public void TakeDamage(int damage)
    {
        health = health - damage;
    }

}
