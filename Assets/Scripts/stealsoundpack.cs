using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stealsoundpack : MonoBehaviour
{
    public AudioClip hitsteal;

   public void playaudio()
    {
        AudioSource.PlayClipAtPoint(hitsteal, transform.position);
    }
}
