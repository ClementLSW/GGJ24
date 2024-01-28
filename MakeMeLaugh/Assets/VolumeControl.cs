using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeControl : MonoBehaviour
{
    public static VolumeControl instance { get; private set; }
    public float musicvolume;
    private void Awake()
    {
        if (instance == null){
            instance = this;
        } else {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        
        musicvolume = 1;
    }

    public void MusicVolumeChange(float value) {
        musicvolume = value;
    }

}
