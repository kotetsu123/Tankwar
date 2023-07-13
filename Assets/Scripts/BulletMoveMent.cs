using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoveMent : MonoBehaviour
{
    public float bulletSpeed = 10.0f;

    public bool isPlayerbullet = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    private void Movement()
    {
        transform.Translate(transform.up * bulletSpeed * Time.deltaTime, Space.World);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //如何判断游戏物体，可以运用标签法
        switch (collision.tag)
        {
            case "Tank":
                if (!isPlayerbullet)
                {
                    collision.SendMessage("Die");
                    Destroy(gameObject);
                }              
                break;
            case "Wall":
                Destroy(collision.gameObject);//销毁墙
                Destroy(gameObject);//销毁子弹
                break;
            case "Boss":
                collision.SendMessage("Boss_Die");
                Destroy(gameObject);
                break;
            case "Enemy":
                if (isPlayerbullet)
                {
                    collision.SendMessage("Die");
                    Destroy(gameObject);
                }
                
                break;
            case "Steal":
                Destroy (gameObject);
                break;
            default:
                break;
        }
    }
}
