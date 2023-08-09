using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MapCrator : MonoBehaviour
{
    //初始化地图物体的数组
    //0.老家，1.墙，2.障碍，3.出生效果，4.水，5.草，6.空气墙
    public GameObject[] MapResource;

    //有东西的列表
    private List<Vector3> Resource_PositionList=new List<Vector3>();


    private void Awake()
    {
        InitMap();

    }
    private void InitMap()
    {
        //实例化老家
        //Instantiate(MapResource[0],new Vector3(0,-8,0),Quaternion.identity);//封装方法后用，封装好的方法，封装的方法用后clone就不会散落在面板当中相当整洁。为了例子，留了一处
        Assamble_MapResource(MapResource[0], new Vector3(0, -8, 0), Quaternion.identity);
        //墙围起来老家
        Assamble_MapResource(MapResource[1], new Vector3(-1, -8, 0), Quaternion.identity);
        Assamble_MapResource(MapResource[1], new Vector3(1, -8, 0), Quaternion.identity);
        for (int i = -1; i < 2; i++)
        {
            Assamble_MapResource(MapResource[1], new Vector3(i, -7, 0), Quaternion.identity);
        }
        //实例化空气墙
        for (int i = -16; i < 17; i++)
        {
            Assamble_MapResource(MapResource[6], new Vector3(i, 9, 0), Quaternion.identity);
        }
        for (int i = -16; i < 17; i++)
        {
            Assamble_MapResource(MapResource[6], new Vector3(i, -9, 0), Quaternion.identity);
        }
        for (int i = -8; i < 9; i++)
        {
            Assamble_MapResource(MapResource[6], new Vector3(-16, i, 0), Quaternion.identity);
        }
        for (int i = -8; i < 9; i++)
        {
            Assamble_MapResource(MapResource[6], new Vector3(16, i, 0), Quaternion.identity);
        }
        //实例化地图
        for (int i = 0; i < 80; i++)
        {
            Assamble_MapResource(MapResource[1], CreateRandomPosition(), Quaternion.identity);//墙的实例化
        }
        for (int i = 0; i < 40; i++)
        {
            Assamble_MapResource(MapResource[2], CreateRandomPosition(), Quaternion.identity);//障碍的实例化
        }
        for (int i = 0; i < 40; i++)
        {
            Assamble_MapResource(MapResource[4], CreateRandomPosition(), Quaternion.identity);//水的实例化
        }
        for (int i = 0; i < 40; i++)
        {
            Assamble_MapResource(MapResource[5], CreateRandomPosition(), Quaternion.identity);//草的实例化
        }

        //初始化敌人

        Assamble_MapResource(MapResource[3], new Vector3(-14, 8, 0), Quaternion.identity);
        Assamble_MapResource(MapResource[3], new Vector3(14, 8, 0), Quaternion.identity);
        Assamble_MapResource(MapResource[3], new Vector3(0, 8, 0), Quaternion.identity);

        InvokeRepeating("CreateEnemy", 4, 6);

        //初始化玩家
        GameObject go = Instantiate(MapResource[3], new Vector3(-2, -8, 0), Quaternion.identity);
        go.GetComponent<Reboot>().createplayer = true;//调用Reboot的组件将createplayer的布尔值调整至true，这样生成的就是玩家了
    }
    private void Assamble_MapResource(GameObject createGameObject,Vector3 createPosiont,Quaternion rotation)
    {
        GameObject mapResource = Instantiate(createGameObject, createPosiont, rotation);
        mapResource.transform.SetParent(gameObject.transform);
        Resource_PositionList.Add(createPosiont);
    }
    //产生随机位置的方法
    private Vector3 CreateRandomPosition()
    {
        //不生成x=-16 ，16的两列，y=-8，8 的位置
        while (true)
        {
            Vector3 createPosition = new Vector3(Random.Range(-15,16),Random.Range(-7,8),0);
            if (!HasResource(createPosition))
            {
              return createPosition;
            }
            
        }
    }
    //用来判断位置列表中是否有这个位置
    private bool HasResource(Vector3 createPos)
    {
        for(int i = 0; i < Resource_PositionList.Count; i++)
        {
            if (createPos == Resource_PositionList[i])
            {
                return true;
            }
        }
        return false;
    }
    //产生敌人的方法
    private void CreateEnemy()
    {
        int num=UnityEngine.Random.Range(0,3);
        Vector3 EnemyPos = new Vector3();
        if (num == 0)
        {
            EnemyPos = new Vector3(-14,8,0);
        }
        else if(num==1)
        {
            EnemyPos=new Vector3(14,8,0);
        }
        else
        {
            EnemyPos = new Vector3(0, 8, 0);
        }
        Assamble_MapResource(MapResource[3], EnemyPos, Quaternion.identity);
    }
}
