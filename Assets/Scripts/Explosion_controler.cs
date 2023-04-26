using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_controler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,0.417f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
