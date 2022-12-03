using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    SpriteRenderer sr;
    GameController controller;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        controller = FindObjectOfType<GameController>();
        ChnageCOlorAndSetTag();
    }
    void ChnageCOlorAndSetTag()
    {
        if (Random.value < 0.5f)
        {
            //blue
            sr.color = controller.colorBlue;
            transform.GetChild(0).tag = "blue";
        }
        else
        {
            //pink
            sr.color = controller.colorPink;
            transform.GetChild(0).tag = "pink";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
