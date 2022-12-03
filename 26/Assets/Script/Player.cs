using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   public enum colorType { blue,pink,}
    public colorType currentColor;

    public int index;
    int maxCount=2;
    SpriteRenderer sr;
    Rigidbody2D rgbd;

    GameController controller;

   public Vector2 maxVelocity;
    public LayerMask PlatformLayer;
    public GameObject ps;
    // Start is called before the first frame update
    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
        controller = FindObjectOfType<GameController>();
        ColorChange(index);

    }

    // Update is called once per frame
    void Update()
    {   if (controller.GameOver) return;
        if (Input.GetButtonDown("Fire1"))
        {
            if (controller.GameOver) return;
            if (index<= maxCount)
            {
                index++;
                if(index == maxCount ) { index = 0; }
                ColorChange(index);

            }
        }
        ClampVelocity();
    }
    void ClampVelocity()
    {
        Vector2 vel = rgbd.velocity;
        if(vel.x > maxVelocity.x)
        {
            vel.x = maxVelocity.x;
        }
        if (vel.y > maxVelocity.y)
        {
            vel.y = maxVelocity.y;
        }
        rgbd.velocity = vel;
    }
    void ColorChange(int colorValue)
    {
        switch (colorValue)
        {
            case 0: currentColor = colorType.blue;
                sr.color = controller.colorBlue;
                break;
            case 1:
                currentColor = colorType.pink;
                sr.color = controller.colorPink;
                break;
            default: Debug.LogError("unable to change the color");
                break;
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
       // if (collision.gameObject.layer != PlatformLayer) return;
        if (collision.collider.tag == "wall")
        {
            return;
        }
        if(collision.collider.tag == currentColor.ToString())
        {
            //good give point to player
        }else if(collision.collider.tag != currentColor.ToString())
        {
            //game Oveer
            Debug.Log("GameOver");
            GameOver();
        }

    }
    public void OnCollisionStay2D(Collision2D collision)
    {
       // if (collision.gameObject.layer != PlatformLayer) return;
        if (collision.collider.tag == "wall")
        {
            return;
        }
        if (collision.collider.tag == currentColor.ToString())
        {
            //good give point to player
        }
        else if (collision.collider.tag != currentColor.ToString())
        {
            //game Oveer
            Debug.Log("GameOver");
            GameOver();
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != PlatformLayer) return;
        
        if (collision.tag == currentColor.ToString())
        {
            //good give point to player
        }
        else if (collision.tag != currentColor.ToString())
        {
            //game Oveer
            Debug.Log("GameOver");
            GameOver();
        }
    } public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer != PlatformLayer) return;
        
        if (collision.tag == currentColor.ToString())
        {
            //good give point to player
        }
        else if (collision.tag != currentColor.ToString())
        {
            //game Oveer
            Debug.Log("GameOver");
            GameOver();
        }
    }
    public void ChangeTheRigidbody()
    {
        rgbd.bodyType = RigidbodyType2D.Dynamic;
    }
    void GameOver()
    {
        controller.GameOver = true;
        Instantiate(ps, transform.position, Quaternion.identity);
        sr.enabled = false;
        rgbd.bodyType = RigidbodyType2D.Kinematic;
        controller.ShowEndCanvas();
    }
}
