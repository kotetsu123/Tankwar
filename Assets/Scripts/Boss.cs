using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private SpriteRenderer sr;
    public GameObject Exp1;
    public AudioClip dieaudio;

    public Sprite DamagedSprite;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    

    public void Boss_Die()
    {
        Player_Manager.Instance.isDefeat = true;
        sr.sprite = DamagedSprite;
        Instantiate(Exp1, transform.position, transform.rotation);
        AudioSource.PlayClipAtPoint(dieaudio, transform.position);
    }
}
