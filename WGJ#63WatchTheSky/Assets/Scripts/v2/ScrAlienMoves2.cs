using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrAlienMoves2 : MonoBehaviour {

    private float screenPosXMin;
    private float screenPosXMax;

    [SerializeField]
    private float moveSpeed;

    private bool isMoveDown;
    private bool isMoveLeft;
    private bool isMoveRight;

    private Vector3 startPosition;
    private Vector3 goalPosition;

    // Use this for initialization
    void Start () {
        ScrGameManager2 scrGM2 = GameObject.Find("GameManager").GetComponent<ScrGameManager2>();

        screenPosXMin = scrGM2.ScreenPosXMin;
        screenPosXMax = scrGM2.ScreenPosXMax;

        isMoveDown = true;
        isMoveLeft = false;
        isMoveRight = false;

        startPosition = gameObject.transform.position;
        goalPosition = new Vector3(startPosition.x, 3.84f, startPosition.z);
    }
	
	// Update is called once per frame
	void Update () {
        if (gameObject.transform.position == goalPosition)
        {
            if (isMoveDown == true)
            {

                isMoveDown = false;

                startPosition = new Vector3(gameObject.transform.position.x, 3.84f, gameObject.transform.position.z);

                int rand = Random.Range(0, 2);

                if (rand == 0)
                {
                    isMoveLeft = true;

                    goalPosition = new Vector3(screenPosXMin, 3.84f, startPosition.z);
                }
                else
                {
                    isMoveRight = true;

                    goalPosition = new Vector3(screenPosXMax, 3.84f, startPosition.z);
                }

            }
            else if (isMoveLeft == true)
            {
                isMoveLeft = false;
                isMoveRight = true;

                startPosition = new Vector3(screenPosXMin, 3.84f, startPosition.z);
                goalPosition = new Vector3(screenPosXMax, 3.84f, startPosition.z);
            }
            else if (isMoveRight == true)
            {
                isMoveLeft = true;
                isMoveRight = false;

                startPosition = new Vector3(screenPosXMax, 3.84f, startPosition.z);
                goalPosition = new Vector3(screenPosXMin, 3.84f, startPosition.z);
            }
        }

        float step = moveSpeed * Time.deltaTime;

        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, goalPosition, step);
    }
}
