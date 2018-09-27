using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrAlienCombat2 : MonoBehaviour {

    [SerializeField]
    private GameObject weaponProjectile;

    private GameObject alienProjectiles;

    private float shootTimer;

    [SerializeField]
    private int healthMax;
    [SerializeField]
    private int health;

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
        alienProjectiles = GameObject.Find("AlienProjectiles");

        shootTimer = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (health <= 0)
        {
            //Loot money

            Destroy(gameObject);
        }

        shootTimer = shootTimer + Time.deltaTime;

        if (weaponProjectile.GetComponent<ScrProjectile2>().GetShootRate() <= shootTimer)
        {
            Vector3 startPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f, gameObject.transform.position.z);
            Vector3 goalPos = new Vector3(gameObject.transform.position.x, -3.84f, gameObject.transform.position.z);

            GameObject instance = Instantiate(weaponProjectile, alienProjectiles.transform);
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
