using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCrator : MonoBehaviour
{
    //初始化地图物体的数组
    //0.老家，1.墙，2.障碍，3.出生效果，4.水，5.草，6.空气墙
    public GameObject[] MapResource;



    private void Awake()
    {
        //实例化老家
        //Instantiate(MapResource[0],new Vector3(0,-8,0),Quaternion.identity);//封装方法后用，封装好的方法，封装的方法用后clone就不会散落在面板当中相当整洁。为了例子，留了一处
        Assamble_MapResource(MapResource[0], new Vector3(0, -8, 0), Quaternion.identity);
        //墙围起来老家
        Assamble_MapResource(MapResource[1], new Vector3(-1, -8, 0), Quaternion.identity);
        Assamble_MapResource(MapResource[1], new Vector3(1, -8, 0), Quaternion.identity);
        for(int i = -1; i < 2; i++)
        {
            Assamble_MapResource(MapResource[1], new Vector3(i, -7, 0), Quaternion.identity);
        }
    }
    private void Assamble_MapResource(GameObject createGameObject,Vector3 createPosiont,Quaternion rotation)
    {
        GameObject mapResource = Instantiate(createGameObject, createPosiont, rotation);
        mapResource.transform.SetParent(gameObject.transform);
    }
}
