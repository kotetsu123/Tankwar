using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //属性值
    public float MoveSpeed = 3.0f;
    private Vector3 bulletEulerAngles;
    private float timeVal;
    private float DefendtimeVal=3.0f;
    private bool isDefended=true;//布尔值默认值false；
    //引用
    public Sprite[] tankSprite;
    public GameObject bulletPrefab;
    public GameObject ExplotionPrefab;
    public GameObject ProtectPrefab;


    private SpriteRenderer sr;//声明图片精灵sr    

    private void Awake()
    {
        sr=GetComponent<SpriteRenderer>();  //在生命周期的最开始调用组件
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //保护状态
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
        //攻击Cd
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
        transform.Translate(Vector3.up * v * MoveSpeed * Time.fixedDeltaTime, Space.World);//垂直方向
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
            return;//优先级 优先v的数值
        }


        float h = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right * h * MoveSpeed * Time.fixedDeltaTime, Space.World);//水平方向的移动，最后的按照移动的坐标轴为世界坐标轴,实时的帧数会导致object出现抽动
        //因此把Time.deltaTime 修改成fixedDeltaTime
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
            //子弹旋转的角度  :当前坦克的角度+子弹旋转的角度 
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
        //玩家生命值-1
        Player_Manager.Instance.PlayerDeath = true;
        //产生爆炸特效
        Instantiate(ExplotionPrefab, transform.position,transform.rotation);
        //死亡
        Destroy(gameObject);
    }
}
