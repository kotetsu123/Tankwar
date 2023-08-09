using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Manager : MonoBehaviour
{
    //����ֵ
    public int LifeValue = 3;
    public int PlayerScore = 0;
    public bool PlayerDeath = false;
    public bool isDefeat=false;
    public GameObject isDefeatUI;

    //����
    public GameObject Born;
    public Text playerScoreText;
    public Text playerLifeValueText;
    //����
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
        playerScoreText.text = PlayerScore.ToString();
        playerLifeValueText.text=LifeValue.ToString();
        if (isDefeat == true)
        {
            isDefeatUI.SetActive(true);
            Invoke("ReturnStartScenes", 3);
            return;
        }
    }
    private void Recover()
    {
        if (LifeValue < 0)
        {
            isDefeat = true;
            //��Ϸʧ�ܣ�����������
            Invoke("ReturnStartScenes", 3);
        }
        else
        {
            LifeValue--;
            GameObject go = Instantiate(Born, new Vector3(-2, -8, 0), Quaternion.identity);
            go.GetComponent<Reboot>().createplayer = true;
            PlayerDeath = false;
        }
    }
    private void ReturnStartScenes()
    {
        SceneManager.LoadScene(0);
    }
}
