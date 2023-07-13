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
        //����ж���Ϸ���壬�������ñ�ǩ��
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
                Destroy(collision.gameObject);//����ǽ
                Destroy(gameObject);//�����ӵ�
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
