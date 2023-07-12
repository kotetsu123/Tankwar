using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Reboot : MonoBehaviour
{
    public GameObject player;

    public GameObject[] enmeyList;

    public bool createplayer = false;
    

    // Start is called before the first frame update
    void Start()
    {
        Invoke("rebootTank", 1f);
        Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void rebootTank()
    {
        if (createplayer)
        {
            Instantiate(player, transform.position, Quaternion.identity);//生成object在特效处
        }
        else
        {
            int num = UnityEngine.Random.Range(0, 2);//随机数返回
            Instantiate(enmeyList[num], transform.position, Quaternion.identity);
        }
    }
}
