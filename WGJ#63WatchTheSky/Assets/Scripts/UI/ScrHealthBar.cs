using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrHealthBar : MonoBehaviour {

    private RectTransform rt;

    // Use this for initialization
    void Start()
    {

        //add canvas compponent
        Canvas c = gameObject.AddComponent<Canvas>();
        c.sortingLayerName = "UI";

        //new image ui
        GameObject healthBar = new GameObject(gameObject.name + "HealthBar");
        healthBar.transform.parent = gameObject.transform;
        healthBar.layer = 5;

        rt = healthBar.AddComponent<RectTransform>();        
        rt.transform.localPosition = new Vector3(-0.5f, 1, 0);        
        rt.pivot = new Vector2(0, 0.5f);
        rt.sizeDelta = new Vector2(1, 0.1f);

        healthBar.AddComponent<CanvasRenderer>();

        Image i = healthBar.AddComponent<Image>();
        i.color = Color.red;

    }

    // Update is called once per frame
    void Update()
    {
        int healthMax;
        int health;

        if (gameObject.name == "Soldier")
        {

            healthMax = gameObject.GetComponent<ScrSoldierCombat>().GetHealthMax();
            health = gameObject.GetComponent<ScrSoldierCombat>().GetHealth();

        }
        else {

            healthMax = gameObject.GetComponent<ScrAlienCombat>().GetHealthMax();
            health = gameObject.GetComponent<ScrAlienCombat>().GetHealth();

        }

        rt.sizeDelta = new Vector2((float)health / (float)healthMax, rt.sizeDelta.y);

    }
}
