using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrTrajectory2 : MonoBehaviour {

    private GameObject soldier;

    private LineRenderer trajectory;

    private float screenPosXMin;   
    private float screenPosXMax;

    // Use this for initialization
    void Start()
    {

        soldier = gameObject.transform.parent.gameObject;

        trajectory = gameObject.GetComponent<LineRenderer>();

        ScrGameManager2 scrGM2 = GameObject.Find("GameManager").GetComponent<ScrGameManager2>();
        screenPosXMin = scrGM2.ScreenPosXMin;
        screenPosXMax = scrGM2.ScreenPosXMax;
    }

    // Update is called once per frame
    void Update()
    {

        trajectory.SetPosition(0, new Vector3(soldier.transform.position.x, soldier.transform.position.y + 0.5f, soldier.transform.position.z));

        Vector3 mousePos = Input.mousePosition;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        if (worldPos.x > screenPosXMin && worldPos.x < screenPosXMax)
        {
            trajectory.SetPosition(1, new Vector3(worldPos.x, 3.84f, 0));
        }
        else if (worldPos.x <= screenPosXMin)
        {
            trajectory.SetPosition(1, new Vector3(screenPosXMin - 0.5f, 3.84f, 0));
        }
        else if (worldPos.x >= screenPosXMax)
        {
            trajectory.SetPosition(1, new Vector3(screenPosXMax + 0.5f, 3.84f, 0));
        }

    }
}
