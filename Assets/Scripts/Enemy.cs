using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{  //����ֵ
    public float MoveSpeed = 3.0f;
    private Vector3 bulletEulerAngles;
    private float v, h;
   
   /* private float DefendtimeVal = 3.0f;
    private bool isDefended = true;//����ֵĬ��ֵfalse��*/
    
    //����
    public Sprite[] tankSprite;
    public GameObject bulletPrefab;
    public GameObject ExplotionPrefab;
    //public GameObject ProtectPrefab;


    //��ʱ��
    private float timeVal;
    private float timeValChangeDirection=4;


    private SpriteRenderer sr;//����ͼƬ����sr    

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();  //���������ڵ��ʼ�������
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
/*        //����״̬
        if (isDefended)
        {
            ProtectPrefab.SetActive(true);
            DefendtimeVal -= Time.deltaTime;
            if (DefendtimeVal <= 0)
            {
                isDefended = false;
                ProtectPrefab.SetActive(false);
            }
        }*/
        //����ʱ����
        if (timeVal >= 3.0f)
        {
            attack();
        }
        else
        {
            timeVal += Time.deltaTime;
        }

    }

    private void FixedUpdate()
    {
        Enemy_Movement();
    }
    private void Enemy_Movement()
    {
        if (timeValChangeDirection >= 4)
        {
            int num = UnityEngine.Random.Range(0, 8);
            if (num > 5)
            {
                v = -1;
                h = 0;
            }
            else if (num == 0)
            {
                v = 1;
                h = 0;
            }
            else if (num > 0 && num <= 2)
            {
                h = -1;
                v = 0;
            }
            else if (num > 2 && num <= 4)
            {
                h = 1;
                v = 0;
            }
            timeValChangeDirection = 0;
        }
        else
        {
            timeValChangeDirection += Time.fixedDeltaTime;
        }
        
         //v = Input.GetAxisRaw("Vertical");
        transform.Translate(Vector3.up * v * MoveSpeed * Time.fixedDeltaTime, Space.World);//��ֱ����
        if (v < 0)
        {
            sr.sprite = tankSprite[2];
            bulletEulerAngles = new Vector3(0, 0, 180);
        }
        else if (v > 0)
        {
            sr.sprite = tankSprite[0];
            bulletEulerAngles = new Vector3(0, 0, 0);
        }
        if (v != 0)
        {
            return;//���ȼ� ����v����ֵ
        }


         //h = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right * h * MoveSpeed * Time.fixedDeltaTime, Space.World);//ˮƽ������ƶ������İ����ƶ���������Ϊ����������,ʵʱ��֡���ᵼ��object���ֳ鶯
        //��˰�Time.deltaTime �޸ĳ�fixedDeltaTime
        if (h < 0)
        {
            sr.sprite = tankSprite[3];
            bulletEulerAngles = new Vector3(0, 0, 90);
        }
        else if (h > 0)
        {
            sr.sprite = tankSprite[1];
            bulletEulerAngles = new Vector3(0, 0, -90);
        }


    }


    private void attack()
    {
            //�ӵ���ת�ĽǶ�  :��ǰ̹�˵ĽǶ�+�ӵ���ת�ĽǶ� 
            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.eulerAngles + bulletEulerAngles));// transform.rotation);
            timeVal = 0;
        
    }
    private void Die()
    {
       /* if (isDefended)
        {
            return;
        }*/
        //������ը��Ч
        Instantiate(ExplotionPrefab, transform.position, transform.rotation);
        //����
        Destroy(gameObject);
    }
}

