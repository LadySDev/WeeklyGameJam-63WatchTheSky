using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrSoldierMoves2 : MonoBehaviour {

    [SerializeField]
    private float moveSpeed;

    private float screenPosXMin;
    private float screenPosXMax;

    // Use this for initialization
    void Start()
    {
        ScrGameManager2 scrGM2 = GameObject.Find("GameManager").GetComponent<ScrGameManager2>();

        screenPosXMin = scrGM2.ScreenPosXMin;
        screenPosXMax = scrGM2.ScreenPosXMax;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("q") && gameObject.transform.position.x > screenPosXMin)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x - moveSpeed, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        else if (Input.GetKey("d") && gameObject.transform.position.x < screenPosXMax)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + moveSpeed, gameObject.transform.position.y, gameObject.transform.position.z);
        }

    }
}
