using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MapCrator : MonoBehaviour
{
    //��ʼ����ͼ���������
    //0.�ϼң�1.ǽ��2.�ϰ���3.����Ч����4.ˮ��5.�ݣ�6.����ǽ
    public GameObject[] MapResource;

    //�ж������б�
    private List<Vector3> Resource_PositionList=new List<Vector3>();


    private void Awake()
    {
        InitMap();

    }
    private void InitMap()
    {
        //ʵ�����ϼ�
        //Instantiate(MapResource[0],new Vector3(0,-8,0),Quaternion.identity);//��װ�������ã���װ�õķ�������װ�ķ����ú�clone�Ͳ���ɢ������嵱���൱���ࡣΪ�����ӣ�����һ��
        Assamble_MapResource(MapResource[0], new Vector3(0, -8, 0), Quaternion.identity);
        //ǽΧ�����ϼ�
        Assamble_MapResource(MapResource[1], new Vector3(-1, -8, 0), Quaternion.identity);
        Assamble_MapResource(MapResource[1], new Vector3(1, -8, 0), Quaternion.identity);
        for (int i = -1; i < 2; i++)
        {
            Assamble_MapResource(MapResource[1], new Vector3(i, -7, 0), Quaternion.identity);
        }
        //ʵ��������ǽ
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
        //ʵ������ͼ
        for (int i = 0; i < 80; i++)
        {
            Assamble_MapResource(MapResource[1], CreateRandomPosition(), Quaternion.identity);//ǽ��ʵ����
        }
        for (int i = 0; i < 40; i++)
        {
            Assamble_MapResource(MapResource[2], CreateRandomPosition(), Quaternion.identity);//�ϰ���ʵ����
        }
        for (int i = 0; i < 40; i++)
        {
            Assamble_MapResource(MapResource[4], CreateRandomPosition(), Quaternion.identity);//ˮ��ʵ����
        }
        for (int i = 0; i < 40; i++)
        {
            Assamble_MapResource(MapResource[5], CreateRandomPosition(), Quaternion.identity);//�ݵ�ʵ����
        }

        //��ʼ������

        Assamble_MapResource(MapResource[3], new Vector3(-14, 8, 0), Quaternion.identity);
        Assamble_MapResource(MapResource[3], new Vector3(14, 8, 0), Quaternion.identity);
        Assamble_MapResource(MapResource[3], new Vector3(0, 8, 0), Quaternion.identity);

        InvokeRepeating("CreateEnemy", 4, 6);

        //��ʼ�����
        GameObject go = Instantiate(MapResource[3], new Vector3(-2, -8, 0), Quaternion.identity);
        go.GetComponent<Reboot>().createplayer = true;//����Reboot�������createplayer�Ĳ���ֵ������true���������ɵľ��������
    }
    private void Assamble_MapResource(GameObject createGameObject,Vector3 createPosiont,Quaternion rotation)
    {
        GameObject mapResource = Instantiate(createGameObject, createPosiont, rotation);
        mapResource.transform.SetParent(gameObject.transform);
        Resource_PositionList.Add(createPosiont);
    }
    //�������λ�õķ���
    private Vector3 CreateRandomPosition()
    {
        //������x=-16 ��16�����У�y=-8��8 ��λ��
        while (true)
        {
            Vector3 createPosition = new Vector3(Random.Range(-15,16),Random.Range(-7,8),0);
            if (!HasResource(createPosition))
            {
              return createPosition;
            }
            
        }
    }
    //�����ж�λ���б����Ƿ������λ��
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
    //�������˵ķ���
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
