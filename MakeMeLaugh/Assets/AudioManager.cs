using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using System.Dynamic;
using FMODUnityResonance;

public class AudioManager : MonoBehaviour
{
    [Header("Volume")]
    [Range(0,1)]
    public float musicVolume = 1;
    public VolumeControl vc;

    private Bus musicBus;

    private List<EventInstance> eventInstances;
    private EventInstance musicEventInstance;

    public static AudioManager instance { get; private set; }
    private void Awake()
    {
        if (instance != null) {
            Debug.LogError("Found more than one Audio Manager in the scene.");
        }
        instance = this;
        eventInstances = new List<EventInstance>();
        musicBus = RuntimeManager.GetBus("bus:/Music");
    }

    private void Start() {
        if(GameObject.Find("VolumeControl")) {
            vc = GameObject.Find("VolumeControl").GetComponent<VolumeControl>();
        }
        InitializeMusic(FMODEvents.instance.music);
    }

    private void Update() {
        musicVolume = vc.musicvolume;
        musicBus.setVolume(musicVolume);
    }

    private void InitializeMusic(EventReference musicEventReference) {
        musicEventInstance = CreateEventInstance(musicEventReference);
        musicEventInstance.start();
    }

    public void PlayOneShot(EventReference sound, Vector3 worldPos) {
        RuntimeManager.PlayOneShot(sound, worldPos);
    }

    public EventInstance CreateEventInstance(EventReference eventReference) {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        eventInstances.Add(eventInstance);
        return(eventInstance);
    }

    private void CleanUp() {
        foreach(EventInstance eventInstance in eventInstances) {
            eventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            eventInstance.release();
        }
    }

    private void OnDestroy() {
        CleanUp();
    }
}
