using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private SpriteRenderer sr;

    public Sprite DamagedSprite;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    

    public void Boss_Die()
    {
        sr.sprite = DamagedSprite;
    }
}
