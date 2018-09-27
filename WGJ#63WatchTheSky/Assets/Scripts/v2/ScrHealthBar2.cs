using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrHealthBar2 : MonoBehaviour {

    private ScrSoldierCombat2 srcSoldatCombat;
    private ScrAlienCombat2 srcAlienCombat;
    private RectTransform rt;

    // Use this for initialization
    void Start () {
        //add canvas compponent
        Canvas c = gameObject.AddComponent<Canvas>();
        c.sortingLayerName = "UI";

        //new image ui
        GameObject healthBar = new GameObject(gameObject.name + "HealthBar");
        healthBar.transform.parent = gameObject.transform;
        healthBar.transform.localPosition = new Vector3(-0.5f, 1, 0);
        healthBar.layer = 5;

        rt = healthBar.AddComponent<RectTransform>();
        rt.pivot = new Vector2(0, 0.5f);
        rt.sizeDelta = new Vector2(1, 0.1f);

        healthBar.AddComponent<CanvasRenderer>();

        Image i = healthBar.AddComponent<Image>();
        i.color = Color.red;

        srcSoldatCombat = gameObject.GetComponent<ScrSoldierCombat2>();
        srcAlienCombat = gameObject.GetComponent<ScrAlienCombat2>();
    }
	
	// Update is called once per frame
	void Update () {
        int healthMax;
        int health;

        if (gameObject.name == "Soldier")
        {

            healthMax = srcSoldatCombat.GetHealthMax();
            health = srcSoldatCombat.GetHealth();

        }
        else
        {

            healthMax = srcAlienCombat.GetHealthMax();
            health = srcAlienCombat.GetHealth();

        }

        rt.sizeDelta = new Vector2((float)health / (float)healthMax, rt.sizeDelta.y);
    }
}
