using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //����ֵ
    public float MoveSpeed = 3.0f;
    private Vector3 bulletEulerAngles;
    private float timeVal;
    private float DefendtimeVal=3.0f;
    private bool isDefended=true;//����ֵĬ��ֵfalse��
    //����
    public Sprite[] tankSprite;
    public GameObject bulletPrefab;
    public GameObject ExplotionPrefab;
    public GameObject ProtectPrefab;


    private SpriteRenderer sr;//����ͼƬ����sr    

    private void Awake()
    {
        sr=GetComponent<SpriteRenderer>();  //���������ڵ��ʼ�������
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //����״̬
        if (isDefended)
        {
            ProtectPrefab.SetActive(true);
            DefendtimeVal -= Time.deltaTime;
            if (DefendtimeVal <= 0)
            {
                isDefended = false;
                ProtectPrefab.SetActive(false);
            }
        }
        //����Cd
        if (timeVal >=1.0f)
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
        Player_Movement();     
    }
    public void Player_Movement()
    {
        float v = Input.GetAxisRaw("Vertical");
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


        float h = Input.GetAxisRaw("Horizontal");
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //�ӵ���ת�ĽǶ�  :��ǰ̹�˵ĽǶ�+�ӵ���ת�ĽǶ� 
            Instantiate(bulletPrefab, transform.position,Quaternion.Euler(transform.eulerAngles+bulletEulerAngles));// transform.rotation);
            timeVal = 0;
        }
    }
    private void Die()
    {
        if (isDefended)
        {
            return;
        }
        //�������ֵ-1
        Player_Manager.Instance.PlayerDeath = true;
        //������ը��Ч
        Instantiate(ExplotionPrefab, transform.position,transform.rotation);
        //����
        Destroy(gameObject);
    }
}
