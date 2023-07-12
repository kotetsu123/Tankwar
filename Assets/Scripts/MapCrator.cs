using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCrator : MonoBehaviour
{
    //��ʼ����ͼ���������
    //0.�ϼң�1.ǽ��2.�ϰ���3.����Ч����4.ˮ��5.�ݣ�6.����ǽ
    public GameObject[] MapResource;



    private void Awake()
    {
        //ʵ�����ϼ�
        //Instantiate(MapResource[0],new Vector3(0,-8,0),Quaternion.identity);//��װ�������ã���װ�õķ�������װ�ķ����ú�clone�Ͳ���ɢ������嵱���൱���ࡣΪ�����ӣ�����һ��
        Assamble_MapResource(MapResource[0], new Vector3(0, -8, 0), Quaternion.identity);
        //ǽΧ�����ϼ�
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
