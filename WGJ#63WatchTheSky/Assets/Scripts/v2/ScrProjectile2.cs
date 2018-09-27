using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrProjectile2 : MonoBehaviour {

    [SerializeField]
    private int attackDamage;
    [SerializeField]
    private float shootRate;
    [SerializeField]
    private float moveSpeed;

    private Vector3 goalPosition;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (goalPosition != null && gameObject.transform.position != goalPosition)
        {

            float step = moveSpeed * Time.deltaTime;

            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, goalPosition, step);
        }
        else if (goalPosition != null && gameObject.transform.position == goalPosition)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        GameObject grandParent = gameObject.transform.parent.gameObject;

        if (grandParent.name == "SoldierProjectiles" && collision.tag == "AlienShip")
        {
            collision.gameObject.GetComponent<ScrAlienCombat2>().TakeDamage(attackDamage);

            Destroy(gameObject);
        }
        else if (grandParent.name == "AlienProjectiles" && collision.tag == "Soldier")
        {
            collision.gameObject.GetComponent<ScrSoldierCombat2>().TakeDamage(attackDamage);

            Destroy(gameObject);
        }
    }

    public float GetShootRate()
    {
        return shootRate;
    }

    public void SetGoalPosition(Vector3 position)
    {
        goalPosition = position;
    }

}
