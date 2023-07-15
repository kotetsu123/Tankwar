using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manager : MonoBehaviour
{
    //属性值
    public int LifeValue = 3;
    public int PlayerScore = 0;
    public bool PlayerDeath = false;

    //引用
    public GameObject Born;
    //单例
    private static Player_Manager instance;

    public static Player_Manager Instance { get => instance; set => instance = value; }

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerDeath == true)
        {
            Recover();
        }
    }
    private void Recover()
    {
        if (LifeValue < 0)
        {
            //游戏失败，返回主界面
        }
        else
        {
            LifeValue--;
            GameObject go = Instantiate(Born, new Vector3(-2, -8, 0), Quaternion.identity);
            go.GetComponent<Reboot>().createplayer = true;
            PlayerDeath = false;
        }
    }
}
