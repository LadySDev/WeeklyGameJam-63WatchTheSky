using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrSoldierTrajectory : MonoBehaviour {

    private GameObject soldier;

    private LineRenderer trajectory;

    // Use this for initialization
    void Start () {

        soldier = gameObject.transform.parent.gameObject;

        trajectory = gameObject.GetComponent<LineRenderer>();

    }
	
	// Update is called once per frame
	void Update () {

        trajectory.SetPosition(0, new Vector3(soldier.transform.position.x, soldier.transform.position.y + 0.5f, soldier.transform.position.z));

        Vector3 mousePos = Input.mousePosition;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        if (worldPos.x > -6.1f && worldPos.x < 4)
        {
            trajectory.SetPosition(1, new Vector3(worldPos.x, 3.84f, 0));
        }
        else if (worldPos.x <= -6.1f)
        {
            trajectory.SetPosition(1, new Vector3(-6.6f, 3.84f, 0));
        }
        else if (worldPos.x >= 4)
        {
            trajectory.SetPosition(1, new Vector3(4.5f, 3.84f, 0));
        }

    }
}
