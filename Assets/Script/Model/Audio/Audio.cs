using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Audio : MonoBehaviour
{
    public enum AudioTypes {sfx, music}
    public AudioTypes audioType;

    public AudioClip audioClip;

    public AudioSource source;

    public void Play()
    {
        if(source.isActiveAndEnabled)
        {
            if(audioType == AudioTypes.sfx)
            {
                source.PlayOneShot(audioClip);
            }

            else
            {
                 source.clip = audioClip;
                 source.Play();
            }
            
        }
    }

}
